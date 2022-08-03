using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {

        Person Create(Person person);

        Person findById(long id);

        List<Person> findAll();

        Person Update(Person person);

        void Delete(long id);


    }
}
