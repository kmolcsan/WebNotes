using Funq;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using WebNotes.ServiceInterface;
using WebNotes.ServiceModel;

namespace WebNotes
{
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("WebNotes", typeof(NotesService).Assembly)
        { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            container.Register<IDbConnectionFactory>(c =>
                new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider)); // In-Memory Sqlite DB

            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                db.CreateTableIfNotExists<Note>();
            }

            SetConfig(new HostConfig
            {
                DefaultContentType = MimeTypes.Json
            });
        }
    }
}
