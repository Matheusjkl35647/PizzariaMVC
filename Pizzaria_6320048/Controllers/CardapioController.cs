using MySql.Data.MySqlClient;
using Pizzaria_6320048.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzaria_6320048.Controllers
{
    public class CardapioController : Controller
    {
        MySqlConnection conn;
        MySqlDataReader dr;

        string StrConn;
        string StrQuery;

        // GET: Cardapio
        public ActionResult Index()
        {
            StrConn = "Server=localhost;Database=cardapio_pizza;Uid=root;Pwd=74859623Mamaed10";
            List<Cardapio> lstCardapios = new List<Cardapio>();

            conn = new MySqlConnection(StrConn);
            StrQuery = "SELECT * FROM cardapios order by Id";

            MySqlCommand comando = new MySqlCommand(StrQuery, conn);
            conn.Open();

            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                Cardapio cardapio = new Cardapio();

                cardapio.Id = Convert.ToInt32(dr["id"]);
                cardapio.Pizza = Convert.ToString(dr["Pizza"]);
                cardapio.Sabor = Convert.ToString(dr["Sabor"]);
                cardapio.ValorInt = Convert.ToDecimal(dr["ValorInt"]);
                cardapio.ValorBrot = Convert.ToDecimal(dr["ValorBrot"]);

                lstCardapios.Add(cardapio);
            }

            return View(lstCardapios);
        }

        public ActionResult Index1()
        {
            StrConn = "Server=localhost;Database=cardapio_pizza;Uid=root;Pwd=74859623Mamaed10";
            List<Cardapio> lstCardapios = new List<Cardapio>();

            conn = new MySqlConnection(StrConn);
            StrQuery = "SELECT * FROM cardapios order by Id";

            MySqlCommand comando = new MySqlCommand(StrQuery, conn);
            conn.Open();

            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                Cardapio cardapio = new Cardapio();

                cardapio.Id = Convert.ToInt32(dr["id"]);
                cardapio.Pizza = Convert.ToString(dr["Pizza"]);
                cardapio.Sabor = Convert.ToString(dr["Sabor"]);
                cardapio.ValorInt = Convert.ToDecimal(dr["ValorInt"]);
                cardapio.ValorBrot = Convert.ToDecimal(dr["ValorBrot"]);

                lstCardapios.Add(cardapio);
            }

            return View(lstCardapios);
        }

        public ActionResult NovaPizza()
        {          
            return View();
        }

        public ActionResult SalvarPizza(Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                StrConn = "Server=localhost;Database=cardapio_pizza;Uid=root;Pwd=74859623Mamaed10";

                conn = new MySqlConnection(StrConn);
                StrQuery = "INSERT INTO cardapios(Pizza, Sabor, ValorInt, ValorBrot) VALUES (@Pizza, @Sabor, @ValorInt, @ValorBrot)";
                MySqlCommand comando = new MySqlCommand(StrQuery, conn);
                comando.Parameters.AddWithValue("@Pizza", cardapio.Pizza);
                comando.Parameters.AddWithValue("@Sabor", cardapio.Sabor);
                comando.Parameters.AddWithValue("@ValorInt", cardapio.ValorInt);
                comando.Parameters.AddWithValue("@ValorBrot", cardapio.ValorBrot);
                conn.Open();
                comando.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            return View(cardapio);
            
        }

        public ActionResult DeletarPizza(Cardapio cardapio)
        {
            
                StrConn = "Server=localhost;Database=cardapio_pizza;Uid=root;Pwd=74859623Mamaed10";

                conn = new MySqlConnection(StrConn);
                StrQuery = "DELETE from cardapios WHERE Id=@Id;";
                MySqlCommand comando = new MySqlCommand(StrQuery, conn);
                comando.Parameters.AddWithValue("@Id", cardapio.Id);
                conn.Open();
                comando.ExecuteNonQuery();
                return RedirectToAction("Index");
        }

        public ActionResult EditarPizza(Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                StrConn = "Server=localhost;Database=cardapio_pizza;Uid=root;Pwd=74859623Mamaed10";

                conn = new MySqlConnection(StrConn);
                StrQuery = "UPDATE cardapios SET Pizza = @Pizza, Sabor = @Sabor, ValorInt = @ValorInt, ValorBrot = @ValorBrot WHERE Id = @Id;";
                MySqlCommand comando = new MySqlCommand(StrQuery, conn);
                comando.Parameters.AddWithValue("@Id", cardapio.Id);
                comando.Parameters.AddWithValue("@Pizza", cardapio.Pizza);
                comando.Parameters.AddWithValue("@Sabor", cardapio.Sabor);
                comando.Parameters.AddWithValue("@ValorInt", cardapio.ValorInt);
                comando.Parameters.AddWithValue("@ValorBrot", cardapio.ValorBrot);
                conn.Open();
                comando.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            return View(cardapio);
        }
    }
}