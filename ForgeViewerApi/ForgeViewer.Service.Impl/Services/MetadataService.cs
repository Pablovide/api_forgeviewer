using Autodesk.Forge;
using Autodesk.Forge.Model;
using ForgeViewer.Service.Contracts.DTO;
using ForgeViewer.Service.Contracts.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForgeViewer.Service.Impl.Services
{
    public class MetadataService : IMetadataService
    {
        private readonly ITokenService _tokenService;
        private readonly Regex regex = new Regex(@"\d+");

        public MetadataService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<object> GetModelMetadata(string urn)
        {
            var modelsApi = await GetModelDerivativeApi();
            var metadata = (AutodeskMetadata)JsonConvert.DeserializeObject<AutodeskMetadata>(JsonConvert.SerializeObject(modelsApi.GetMetadata(urn)));
            var guid = metadata.Data.Metadata.First().Value.Guid;
            var hierarchy = (AutodeskMetadata)JsonConvert.DeserializeObject<AutodeskMetadata>(JsonConvert.SerializeObject(modelsApi.GetModelviewMetadata(urn, guid)));
            var properties = (AutodeskMetadata)JsonConvert.DeserializeObject<AutodeskMetadata>(JsonConvert.SerializeObject(modelsApi.GetModelviewProperties(urn, guid)));
            var asgag = PrepareRawData(hierarchy, properties);

            return asgag;
        }

        private Dictionary<string, List<Dictionary<string, string>>> PrepareRawData(AutodeskMetadata hierarchy, AutodeskMetadata properties)
        {
            var tables = new Dictionary<string, List<Dictionary<string, string>>>();
            foreach (var obj in hierarchy.Data.Objects["0"].Objects.Values)
            {
                List<int> idsOnCategory = new List<int>();
                GetAllElementsOnCategory(idsOnCategory, obj.Objects);

                var rows = new List<Dictionary<string, string>>();
                foreach (var id in idsOnCategory)
                {
                    var columns = GetProperties(id, properties);
                    rows.Add(columns);
                }
                tables.Add(obj.Name, rows);
            }
            return tables;

        }

        private Dictionary<string, string> GetProperties(int id, AutodeskMetadata properties)
        {
            var data = new Dictionary<string, string>();
            foreach (var obj in properties.Data.Collections.Values)
            {
                if (obj.Id != id) continue;
                data.Add("Viewer ID", id.ToString());
                data.Add("Revit ID", regex.Match(obj.Name).Value);
                data.Add("Name", obj.Name.Replace('[' + data["Revit ID"] + ']', "").Trim());

                foreach (var propGroup in obj.Properties)
                {
                    foreach(var prop in propGroup)
                    {
                        foreach(var propName in prop)
                        {
                            data.Add($"{propGroup.Name} : {propName.Name}", obj.Properties[propGroup.Name][propName.Name].Value);
                        }

                    }
                }
            }
            return data;
        }

        private void GetAllElementsOnCategory(List<int> idsOnCategory, Dictionary<string, AutodeskMetadataObject> categories)
        {
            foreach (var category in categories.Values)
            {
                if (category.Objects == null)
                {
                    if (!idsOnCategory.Contains(category.Id))
                    {
                        idsOnCategory.Add(category.Id);
                    }
                }
                else
                {
                    GetAllElementsOnCategory(idsOnCategory, category.Objects);
                }
            }
        }

        private async Task<DerivativesApi> GetModelDerivativeApi()
        {
            var token = await _tokenService.GetPrivateTokenAsync();
            var config = new Autodesk.Forge.Client.Configuration();
            config.AccessToken = token.AccessToken;
            return new DerivativesApi(config);
        }

    }
}
