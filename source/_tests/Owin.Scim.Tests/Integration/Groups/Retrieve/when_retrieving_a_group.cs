namespace Owin.Scim.Tests.Integration.Groups.Retrieve
{
    using System.Net;
    using System.Net.Http;

    using Machine.Specifications;

    using Model.Groups;

    using v2.Model;

    public class when_retrieving_a_group : using_existing_user_and_group
    {
        Because of = () =>
        {
            Response = Server
                .HttpClient
                .GetAsync("v2/groups/" + GroupId)
                .Result;
            
            RetrievedGroup = Response.StatusCode == HttpStatusCode.OK
                ? Response.Content.ScimReadAsAsync<ScimGroup2>().Result
                : null;

            Error = Response.StatusCode == HttpStatusCode.BadRequest
                ? Response.Content.ScimReadAsAsync<Model.ScimError>().Result
                : null;
        };

        protected static string GroupId;

        protected static ScimGroup GroupDto;

        protected static ScimGroup RetrievedGroup;

        protected static HttpResponseMessage Response;

        protected static Model.ScimError Error;
    }
}