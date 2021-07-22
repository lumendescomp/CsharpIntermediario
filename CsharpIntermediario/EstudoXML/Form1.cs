using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EstudoXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CriarContato();
            label1.Text = CarregarTitulo();
            CarregarContatos();
        }

        public string CarregarTitulo()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C: \Users\DINTER - PPGEFHC - IFBA\source\repos\CsharpBasico\EstudoXML\XMLFile1.xml");
            XmlNode noTitulo = documentoXml.SelectSingleNode("/agenda/titulo");
            return noTitulo.InnerText;
        }

        public void CarregarContatos()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C: \Users\DINTER - PPGEFHC - IFBA\source\repos\CsharpBasico\EstudoXML\XMLFile1.xml");
            XmlNodeList contatos = documentoXml.SelectNodes("//contatos");
            foreach (XmlNode contato in contatos)
            {
                string representacaoContato = "";
                string id = contato.Attributes["id"].Value;
                string nome = contato.Attributes["nome"].Value;
                string idade = contato.Attributes["idade"].Value;
                representacaoContato = nome + ", " + idade + ", " + id;
                listBox1.Items.Add(representacaoContato);
            }
        }
        public void CriarContato()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C: \Users\DINTER - PPGEFHC - IFBA\source\repos\CsharpBasico\EstudoXML\XMLFile1.xml");
            XmlAttribute atributoId = documentoXml.CreateAttribute("id");
            atributoId.Value = "5";
            XmlAttribute atributoNome = documentoXml.CreateAttribute("nome");
            atributoNome.Value = "Maria";
            XmlAttribute atributoIdade = documentoXml.CreateAttribute("idade");
            atributoIdade.Value = "4";
            XmlNode novoContato = documentoXml.CreateElement("contato");
            novoContato.Attributes.Append(atributoId);
            novoContato.Attributes.Append(atributoNome);
            novoContato.Attributes.Append(atributoIdade);
            XmlNode contatos = documentoXml.SelectSingleNode("//contatos");
            contatos.AppendChild(novoContato);
            documentoXml.Save(@"C: \Users\DINTER - PPGEFHC - IFBA\source\repos\CsharpBasico\EstudoXML\XMLFile1.xml");
        }
    }
}

