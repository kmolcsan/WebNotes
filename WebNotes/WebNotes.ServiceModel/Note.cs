using System.Collections.Generic;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace WebNotes.ServiceModel
{
    /// <summary>
    /// Get Notes from the WebNotes database. Query parameter optional.
    /// </summary>
    [Route("/api/notes", "GET")]
    public class GetNotes : IReturn<GetNotesResponse>
    {
        public string Query { get; set; }
    }

    public class GetNotesResponse
    {
        public List<Note> Results { get; set; }
    }

    /// <summary>
    /// Returns a unique Note by Id
    /// </summary>
    [Route("/api/notes/{Id}", "GET")]
    public class GetNote : IReturn<Note>
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Add a new Note to the database
    /// </summary>
    [Route("/api/notes", "POST")]
    public class CreateNote : IReturn<Note>
    {
        public string Body { get; set; }
    }

    /// <summary>
    /// Default Note Definition
    /// </summary>
    public class Note
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Body { get; set; }
    }

}