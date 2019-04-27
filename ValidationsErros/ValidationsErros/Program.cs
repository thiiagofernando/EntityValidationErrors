using System;
using System.Data.Entity.Validation;
using ValidationsErros.Data;
using ValidationsErros.Models;

namespace ValidationsErros
{
    class Program
    {
        static void Main(string[] args)
        {
            NovoEmail();
        }

        public static void NovoEmail()
        {
            using (ConexaoBdContext db = new ConexaoBdContext())
            {
                Pessoa pessoa = new Pessoa
                {
                    Nome = "Thiago",
                    Email = "thiago.fernando@msn.com"
                };
                try
                {
                    db.Pessoas.Add(pessoa);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                     throw;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
