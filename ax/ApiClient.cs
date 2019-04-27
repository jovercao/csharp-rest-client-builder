/*
* 本文档由swagger客户端生成工具自动生成
* 作者： Jover
*/
using Newtonsoft.Json;
using RestSharp;

namespace RestApiClient
{
    /// <summary>
    /// RestSharp 文档地址 https://github.com/restsharp/RestSharp
    /// swagger 地址：http://124.16.7.242:8082/swagger/docs/v1
    /// </summary> 
    public class ApiClient
    {
        private RestClient client;
        public ApiClient(string url)
        {
            client = new RestClient(url);
        }


        /// <summary>
        /// 3.3.1.1查询排班计划(鑫)
        /// </summary>
        /// <param name="deptId"></param>
        public ClientModels.RetV_T_MEA_SHIFTPLAN GetShiftPlans(int deptId)
        {
            var request = new RestRequest("/api/MEAShift/GetShiftPlans", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.RetV_T_MEA_SHIFTPLAN>(response.Content);
        }

        /// <summary>
        /// 3.3.1.2新增/修改排班计划(鑫)
        /// </summary>
        /// <param name="model"></param>
        public ClientModels.ResultModel AddUpdateShiftPlans(ClientModels.V_T_MEA_SHIFTPLAN[] model)
        {
            var request = new RestRequest("/api/MEAShift/AddUpdateShiftPlans", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.3.1.2删除排班计划(鑫)
        /// </summary>
        /// <param name="FID"></param>
        public ClientModels.ResultModel DelShiftPlans(int FID)
        {
            var request = new RestRequest("/api/MEAShift/DelShiftPlans", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.3.1.3启用/禁用排班计划(鑫)
        /// </summary>
        /// <param name="ID">记录ID</param>
        /// <param name="ISOPEN">1启用或0禁用</param>
        public ClientModels.ResultModel PlansIsOpen(int ID,int ISOPEN)
        {
            var request = new RestRequest("/api/MEAShift/PlansIsOpen", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.3.2.1生成排班记录(鑫)
        /// </summary>
        /// <param name="model">生成排班记录入参</param>
        public ClientModels.ResultModel CreateShift(ClientModels.CreateShiftActionModel model)
        {
            var request = new RestRequest("/api/MEAShift/CreateShift", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.3.3.1设置自动生成排班记录参数(鑫)
        /// </summary>
        /// <param name="content"></param>
        public ClientModels.ResultModel UpdateConfig(string content)
        {
            var request = new RestRequest("/api/MEAShift/UpdateConfig", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.4.1.1查询排班记录(鑫)
        /// </summary>
        /// <param name="FID"></param>
        public ClientModels.RetV_T_MEA_SHIFT GetShifts(int FID)
        {
            var request = new RestRequest("/api/MEAShift/GetShifts", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.RetV_T_MEA_SHIFT>(response.Content);
        }

        /// <summary>
        /// 3.4.2.1新增/修改排班记录(鑫)
        /// </summary>
        /// <param name="models"></param>
        public ClientModels.ResultModel AddUpdateShift(ClientModels.V_T_MEA_SHIFT[] models)
        {
            var request = new RestRequest("/api/MEAShift/AddUpdateShift", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.4.2.1删除排班记录(鑫)
        /// </summary>
        /// <param name="FID"></param>
        public ClientModels.ResultModel DelShift(int FID)
        {
            var request = new RestRequest("/api/MEAShift/DelShift", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.4.2.2启用/禁用排班记录（鑫）
        /// </summary>
        /// <param name="ID">记录ID</param>
        /// <param name="ISOPEN">1启用或0禁用</param>
        public ClientModels.ResultModel SHIFTIsOpen(int ID,int ISOPEN)
        {
            var request = new RestRequest("/api/MEAShift/SHIFTIsOpen", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.5.1.1：查询班别可预约号源(鑫)
        /// </summary>
        /// <param name="ID">记录ID</param>
        public ClientModels.Ret_GetBALLNUM GetBALLNUM(int ID)
        {
            var request = new RestRequest("/api/MEAShift/GetBALLNUM", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.Ret_GetBALLNUM>(response.Content);
        }

        /// <summary>
        /// 3.6.1.1查询班别(鑫)
        /// </summary>
        /// <param name="FID">undefined</param>
        public ClientModels.RetV_T_MEA_SHIFTCLASS GetShiftClass(int FID)
        {
            var request = new RestRequest("/api/MEAShift/GetShiftClass", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.RetV_T_MEA_SHIFTCLASS>(response.Content);
        }

        /// <summary>
        /// 3.6.1.2新增/修改班别(鑫)
        /// </summary>
        /// <param name="model">班别</param>
        public ClientModels.ResultModel AddUpdateShiftClass(ClientModels.V_T_MEA_SHIFTCLASS[] model)
        {
            var request = new RestRequest("/api/MEAShift/AddUpdateShiftClass", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.6.1.3删除班别(鑫)
        /// </summary>
        /// <param name="FID"></param>
        public ClientModels.ResultModel DelShiftClass(int FID)
        {
            var request = new RestRequest("/api/MEAShift/DelShiftClass", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.6.2.1查询设备类型(鑫)
        /// </summary>
        /// <param name="FID"></param>
        /// <param name="deptId"></param>
        public ClientModels.RetV_T_MEA_DEVICETYPE GetDeviceTypes(int FID,int deptId)
        {
            var request = new RestRequest("/api/MEAShift/GetDeviceTypes", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.RetV_T_MEA_DEVICETYPE>(response.Content);
        }

        /// <summary>
        /// 3.6.2.2新增/修改设备类型(鑫)
        /// </summary>
        /// <param name="model">设备类型集合</param>
        public ClientModels.ResultModel AddUpdateDeviceTypes(ClientModels.V_T_MEA_DEVICETYPE[] model)
        {
            var request = new RestRequest("/api/MEAShift/AddUpdateDeviceTypes", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.6.2.3：删除设备类型(鑫)
        /// </summary>
        /// <param name="FID"></param>
        public ClientModels.ResultModel DelDeviceType(int FID)
        {
            var request = new RestRequest("/api/MEAShift/DelDeviceType", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.6.3.1查询预约渠道(鑫)
        /// </summary>
        /// <param name="FID"></param>
        /// <param name="deptId"></param>
        /// <param name="mediumId"></param>
        public ClientModels.RetV_T_MEA_MEDIUM GetMediums(int FID,int deptId,int mediumId)
        {
            var request = new RestRequest("/api/MEAShift/GetMediums", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.RetV_T_MEA_MEDIUM>(response.Content);
        }

        /// <summary>
        /// 3.6.3.2新增/修改预约渠道(鑫)
        /// </summary>
        /// <param name="model"></param>
        public ClientModels.ResultModel AddUpdateMediums(ClientModels.V_T_MEA_MEDIUM[] model)
        {
            var request = new RestRequest("/api/MEAShift/AddUpdateMediums", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 3.6.3.3：删除预约渠道(鑫)
        /// </summary>
        /// <param name="FID"></param>
        public ClientModels.ResultModel DelMediums(int FID)
        {
            var request = new RestRequest("/api/MEAShift/DelMediums", RestSharp.Method.POST);
            var response = client.Post(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.ResultModel>(response.Content);
        }

        /// <summary>
        /// 查询科室列表(鑫)
        /// </summary>

        public ClientModels.DEPT_DICT[] GetDeptList()
        {
            var request = new RestRequest("/api/MEAShift/GetDeptList", RestSharp.Method.GET);
            var response = client.Get(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientModels.DEPT_DICT[]>(response.Content);
        }

    }
}