using Newtonsoft.Json;

namespace smartslotdwapi.SmartSlotApi;

public class SmartSlotApi<T> {
    public List<T> GetHttpGet(string uri) {
        var response = new List<T>();
        try {
            using (HttpClient httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage httpResponse = httpClient.GetAsync($"{uri}").Result) {
                    if (httpResponse.IsSuccessStatusCode) {
                        var result = httpResponse.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<List<T>>(result);
                    }
                }
            }
        }
        catch (Exception) {
        }
        return response;
    }
}
