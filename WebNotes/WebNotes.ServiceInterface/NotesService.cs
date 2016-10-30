using ServiceStack;
using ServiceStack.OrmLite;
using WebNotes.ServiceModel;

namespace WebNotes.ServiceInterface
{
    public class NotesService : Service
    {
        public object Get(GetNotes request)
        {
            if (request.Query.IsEmpty())
            {
                return new GetNotesResponse { Results = Db.Select<Note>() };
            }
            else
            {
                return new GetNotesResponse { Results = Db.Select<Note>(n => n.Body.Contains(request.Query)) };
            }
        }

        public object Get(GetNote request)
        {
            return Db.SingleById<Note>(request.Id);
        }

        public object Post(CreateNote request)
        {
            var note = new Note { Body = request.Body };
            Db.Save(note);
            return note;
        }
    }
}