module Paket.JSONLDSpecs

open Paket
open NUnit.Framework
open FsUnit
open System.IO

open Paket.NuGetV3

[<Test>]
let ``can extract all versions from Rx-Platformservice.json``() = 
    File.ReadAllText "JSON-LD/Rx-PlatformServices.json" 
    |> extractVersions
    |> shouldEqual 
           [| "2.0.20304-beta"; "2.0.20612-rc"; "2.0.20622-rc"; "2.0.20814"; "2.0.20823"; "2.0.21030"; "2.0.21103"; 
              "2.0.21114"; "2.1.30204"; "2.1.30214"; "2.2.0-beta"; "2.2.0"; "2.2.1-beta"; "2.2.1"; "2.2.2"; "2.2.3"; 
              "2.2.4"; "2.2.5"; "2.3.0" |]

let rootJSON = """{
 "version": "3.0.0-preview.1",
 "resources": [
  {
   "@id": "https://preview-search.nuget.org/search/query",
   "@type": "SearchQueryService"
  },
  {
   "@id": "https://preview-search.nuget.org/search/autocomplete",
   "@type": "SearchAutocompleteService"
  },
  {
   "@id": "http://api-metrics.nuget.org/DownloadEvent",
   "@type": "MetricsService"
  },
  {
   "@id": "https://az320820.vo.msecnd.net/registrations-0/",
   "@type": "RegistrationsBaseUrl"
  },
  {
   "@id": "http://preview.nuget.org/ver3-ctp1/islatest/segment_index.json",
   "@type": "LatestVersionsList"
  },
  {
   "@id": "http://preview.nuget.org/ver3-ctp1/islateststable/segment_index.json",
   "@type": "LatestStableVersionsList"
  },
  {
   "@id": "http://preview.nuget.org/ver3-ctp1/allversions/segment_index.json",
   "@type": "AllVersionsList"
  },
  {
   "@id": "http://www.nuget.org/api/v2",
   "@type": "LegacyGallery"
  }
 ],
 "@context": {
  "@vocab": "http://schema.nuget.org/services#"
 }
}"""

[<Test>]
let ``can extract search service``() = 
    rootJSON
    |> getSearchAutocompleteService
    |> shouldEqual (Some "https://preview-search.nuget.org/search/autocomplete")
  
[<Test>]
let ``can parse autocomplete response for packages``() =
    let response = """{"@context":{"@vocab":"http://schema.nuget.org/schema#"},"totalHits":230,"timeTakenInMs":57,"index":"ng-v3search-nov13-2014","data":["Newtonsoft.Json","json-ld.net","JSON","json2","JSON3","Jv.Json","oak-json","lee.json","jsonorm","jsoncpp","JsonFx","JsonRPC","JsonLite","JsonTree","FM.JsonNet","Windy.Json","Mvc.Jsonp","System.Json","Kiwi.Json","Mext.Json","Simple.Json","squire.json","JsonValue","JsonToolkit","JsonClient","JsonLight","JsonFSharp","JsonConfig","JsonSettings","JsonToggler","JsonAnalyser","JsonAssertions","WebApi.JsonP","Salient.JsonClient","Rebus.Newtonsoft.JsonNET","Nancy.Serialization.JsonNet","SisoDb.JsonNet","JsonRpcRT","EBA.Json.NewtonsoftJson","Simple.Web.JsonFx","Simple.Web.JsonNet","JsonFromUri","Daishi.JsonParser","ENodeX.JsonNet","ECommon.JsonNet","HalJsonNet","Tavis.JsonPatch","Tavis.JsonPointer","Belt.Serialization.JsonNet","MyJsonParser","Intelliplan.JsonNet","GeoJsonSharp","Gbase.NLog.JsonTarget","Newtonsoft.JsonResult","Elasticsearch.Net.JsonNET","JsonPoke.MSBuild","JsonAssertions.dll","Marvin.JsonPatch","fastJSON","jayrock-json","agilex.json.client","json-serialize","Json-to-HTML-Table","FubuJson","codetitans-json","Bifrost.JSON","clojure.data.json","Manatee.Json","Newtonsoft.Json.Test","ctstone.Json","Fastest.Json","Json.NetMF","enode.jsonnet","Echovoice.JSON","Fractions.Json","System.Text.Json","jsoncpp.redist","jsoncpp.symbols","Eto.Forms.Json","NXKit.XForms.Json","log4net.Ext.Json","NetJSON","LitJson","Cameronism.Json","JsonRpcHandler","netfx-System.Net.Http.JsonContent","netfx-System.JsonSerializer","jsonToFormUrlencoded","CityIndex.JsonClient","HashFoo.Rest.Serializers.JsonNet","Pathoschild.Http.Formatters.JsonNet","AustinHarris.JsonRpc","CollectionJsonFormatter","WebApi.JsonWebToken","AzureJsonStore","Two10.AzureJsonStore","MVC.JsonWebToken","Chinchilla.Serializers.JsonNET","Aq.ExpressionJsonSerializer","HalJsonConverter","Forge.Persistence.Formatters.JsonNet","NodaTime.Serialization.JsonNet","FireSharp.Serialization.JsonNet","Wave.Serialization.JsonDotNet","WebApi.Formatting.JsonMask","LightNode.Formatter.JsonNet","Minion.Web.JsonWebApi","EsentJsonStorage","GeoJSON4EntityFramework","GeoJSON4EntityFramework5","JsonPrettyPrinter","Idecom.Bus.Serializer.JsonNet","WcfJsonFormatter","Intelliplan.JsonNet.NodaTime","WcfJsonNetFormatter","MayBee.Serialization.JsonNet","Finalist.Serialization.JsonNet","ThinkLib.JsonNet","MFiles.VaultJsonTools","RomanticWeb.JsonLd","JsonBootstrapMenu","DotJson.Source","DynamicJson","SimpleJson","GeoJSON.Net","Cavity.Data.Json.Xunit","FubuMVC.Json","Newtonsoft.Json.Glimpse","ExfSoft.Json","FlitBit.Json","Simple.Json-no-webapi","Insight.Database.Json","MicroJson","Nimbus.Serializers.Json","CUL.fastJSON","Griffin.Framework.Json","Touch.Serialization.Json","log4net.Ext.Json.1.2.10","log4net.Ext.Json.1.2.13","SkinnyJson","Newtonsoft.Json.Ninject","CollectionJson","AcspNet.Json","ConfigJson","FSharpEnt.Json","Tocsoft.Common.Helpers.Json","ComputerBeacon.Json","NMoneys.Serialization.Json_NET","Enyim.Memcached.Transcoders.Json","StaticVoid.Json","TINA-ORM-SERIALIZATION-JSONNET","fastJSON-KAyub","PushoverQ.Json","SchedulesDirect.Json","pavsaund.test.Bifrost.JSON","SharpExtensions.Json","HaveBoxJSON","FifteenBelow.Json","SpecFlow.Reporting.Json","Skybrud.WebApi.Json","FsPickler.Json","Terradue.GeoJson","ResxToJson","AcspNet.Responses.Json","CollectionJson.Server","CollectionJson.Client","SkinnyJson_SN","Moonmile.ExDoc.Json","Nancy.CollectionJson","Orleans.Serialization.Newtonsoft.Json","Nancy.Serialization.NetJSON","Weingartner.Json.Migration.Fody","System.Runtime.Serialization.Json","DynamicJsonForDotNET","netfx-System.JsonSerializer.Tests.xUnit","MongoJsonActiveMQ","netfx-System.Net.Http.JsonContent.Tests","netfx-WebApi.JsonNetFormatter","WebAPIContrib.Formatters.JsonNet","Pathoschild.FluentHttpClient.Formatters.JsonNet","AustinHarris.JsonRpc.AspNet","JsonDotNet.CustomContractResolvers","MvvmCross.HotTuna.Plugin.JsonLocalisation","RESTWebClientJsonWP","MassTransit.Serialization.JsonNet","WebApi.JsonWebToken.Binaries","ArcGIS.PCL.JsonDotNetSerializer","Kipware.MvvmCross.Plugins.AsyncJsonSerializer","ArcGIS.PCL.JsonDotNetSerializer.Signed","Xamarin.Forms.Labs.Services.Serialization.JsonNET","AweSamNet.JsonObfuscator","EventStore.Serialization.Json","NanoMessageBus.Json.NET","RabbitBus.Serialization.Json","WebApiContrib.Formatting.Jsonp","FizzyLogic.DynamicJson","HashFoo.Nts.GeoJson","NEventStore.Serialization.Json","NEventStore.Serialization.Json-Signed","Manatee.Trello.ManateeJson","Manatee.Trello.NewtonsoftJson","SharpExtensions.Json.Assembly","RedDog.Messenger.Serialization.Json","Zoltu.MediaFormatter.Json","ResxToJson.MSBuild","Terradue.OpenSearch.GeoJson","Newtonsoft.Json.NoBrowser","Orleans.Serialization.RavenDB.Json","MagicalUnicornMvcApiJsonToolkit","AcklenAvenue.Dispatcher.MessageSerializer.JsonNET","netfx-Microsoft.ApplicationServer.Http.JsonNetMediaTypeFormatter","FluentDataContract.Adapters.Json","WebApiContrib.Formatting.CollectionJson","jsoneditoronline.TypeScript.DefinitelyTyped","MvvmCross.HotTuna.Plugin.Json","DocaLabs.Http.Client.with.NewtonSoft.Json.Serializer","Polaris.ArenaNet.GuildWars2.Json","WebApiContrib.Formatting.CollectionJson.Server","WebApiContrib.Formatting.CollectionJson.Client","WebApiContrib.CollectionJson","FunScript.TypeScript.Binding.jsoneditoronline","NetTopologySuite.IO.GeoJSON","PersistenceRest.EsentJson.Owin","json-pointer.TypeScript.DefinitelyTyped","ImageResizer.Plugins.DiagnosticJson","FunScript.TypeScript.Binding.json_pointer","Sixeyed.Caching.Serialization.Serializers.Json-Bardock","JSONStream.TypeScript.DefinitelyTyped","jsonwebtoken.TypeScript.DefinitelyTyped","Microsoft.Framework.ConfigurationModel.Json"],"answeredBy":"nuget-prod-0-v3search_IN0-search"}"""

    let packages = NuGetV3.extractPackages response
    packages |> shouldContain "Newtonsoft.Json"
    packages |> shouldContain "json2"

[<Test>]
let ``can parse autocomplete response for versions``() =
    let response = """{"@context":{"@vocab":"http://schema.nuget.org/schema#"},"totalHits":37,"timeTakenInMs":2,"index":"ng-v3search-nov13-2014","data":["3.5.8","4.0.1","4.0.2","4.0.3","4.0.4","4.0.5","4.0.6","4.0.7","4.0.8","4.5.1","4.5.2","4.5.3","4.5.4","4.5.5","4.5.6","4.5.7","4.5.8","4.5.9","4.5.10","4.5.11","5.0.1","5.0.2","5.0.3","5.0.4","5.0.5","5.0.6","5.0.7","5.0.8","6.0.1-beta1","6.0.1","6.0.2","6.0.3","6.0.4","6.0.5","6.0.6","6.0.7","6.0.8"],"answeredBy":"nuget-prod-0-v3search_IN2-search"}"""

    let packages = NuGetV3.extractVersions response
    packages |> shouldContain "4.0.1"
    packages |> shouldContain "4.0.5"