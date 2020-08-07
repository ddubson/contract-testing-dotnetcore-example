using System.Collections.Generic;
using System.Linq;
using API.Domain;

namespace API.Repositories
{
    public class PersonProfileRepository
    {
        private Dictionary<long, PersonProfile> personProfiles;

        public PersonProfileRepository()
        {
            personProfiles = new Dictionary<long, PersonProfile>
            {
                {1L, new PersonProfile {Id = 1L, FirstName = "Jill", LastName = "Doe"}},
                {2L, new PersonProfile {Id = 2L, FirstName = "James", LastName = "Mill"}},
                {3L, new PersonProfile {Id = 3L, FirstName = "Julie", LastName = "Styles"}}
            };
        }

        public IEnumerable<PersonProfile> FetchAll() => personProfiles.Values;

        public PersonProfile FindById(long id) => personProfiles
            .FirstOrDefault(p => p.Key == id)
            .Value;
    }
}