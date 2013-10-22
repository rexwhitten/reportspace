using System.Web.Routing;

using RestfulRouting;

[assembly: WebActivator.PreApplicationStartMethod(typeof(ReportSpace.CustomerDashboard.Web.Routes), "Start")]

namespace ReportSpace.CustomerDashboard.Web
{
    using ReportSpace.CustomerDashboard.Web.Controllers;

    public class Routes : RouteSet
    {
        public static void Start()
        {
            var routes = RouteTable.Routes;
            routes.MapRoutes<Routes>();
        }

        public override void Map(IMapper map)
        {
            map.DebugRoute("routedebug");

            map.Root<CategoryController>(c => c.Index("/"));

            map.Resources<UserController>();
            
            map.Resources<ReportController>(c => c.Member(x => x.Get("Search")));

            map.Resources<ReportParameterController>(reportParameter => reportParameter.Only("Index"));

            map.Resources<CategoryController>(category => category.Only("Index"));
            
            map.Resources<ClientController>(client => client.Only("Index"));
         
            map.Resources<RoleController>(r => r.WithFormatRoutes());

            map.Resource<FileController>(file => file.Only("Create"));
            
            map.Resource<SearchController>(s => s.Only("New", "Create"));

            map.Resources<AccountController>(
                account =>
                    {
                        account.Except("new", "create", "show", "index", "update", "destroy");
                        account.Collection(x => x.Get("Login"));
                        account.Collection(x => x.Post("Login"));
                        account.Collection(x => x.Get("Register"));
                        account.Collection(x => x.Post("Register"));
                        account.Collection(x => x.Put("Confirm"));
                    });
        }
    }
}