using Nancy;
using NancyTest.Objects;
using Nancy.ModelBinding;

namespace NancyTest.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters =>
            {
                var blogPost = new BlogPost
                {
                    Id = 1,
                    Title = "From ASP.NET MVC to Nancy - Part 2",
                    Content = "Lorem ipsum...",
                    Tags = { "c#", "aspnetmvc", "nancy" }
                };

                return View["Index", blogPost];
            };

            Get["/new/"] = parameters =>
            {
                var blogPost = new BlogPost();

                return View["New", blogPost];
            };

            Post["/new/"] = parameters =>
            {
                var blogPost = this.Bind<BlogPost>();
                // Redirects the user to our Index action with a "status" value as a querystring.
                return Response.AsRedirect("/?status=added&title=" + blogPost.Title);
            };
        }
    }
}