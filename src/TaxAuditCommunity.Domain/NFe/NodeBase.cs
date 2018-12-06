using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Xml;

namespace TaxAuditCommunity.Domain.NFe
{
    public abstract class NodeBase<TKey> : Nodebase
        where TKey : IComparable<TKey>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }
    }

    public abstract class NodeBase<TKey, TintId> : Nodebase
        where TKey : IEquatable<TKey>
        where TintId : IComparable<TintId>
    {
        public virtual TKey Id { get; set; }
    }

    [NotMapped]
    public abstract class Nodebase
    {
        public virtual void SetProperties(XmlNode node)
        {
            try
            {
                if (this.GetType().Name == "NFe")
                {
                    var chave = node.OwnerDocument.GetElementsByTagName("infNFe")[0].Attributes["Id"].InnerText.Replace("NFe","");
                    this.GetType().GetProperty("Id").SetValue(this, chave);
                }

                string NodeName = node.Name;
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if (HasProperty(attr.Name))
                    {

                        var attribute = this.GetType().GetProperty(attr.Name).PropertyType;
                        dynamic ret = null;

                        if (IsField(attribute, attr.Value, out ret))
                        {
                            if (this.GetType().Name == "infNFe" & attr.Name == "Id")
                            {
                                GetType().GetProperty(attr.Name).SetValue(this, ((string)ret).Replace("NFe", ""));
                            }
                            else
                            {
                                GetType().GetProperty(attr.Name).SetValue(this, ret);
                            }
                        }
                    }
                }
                if (node.HasChildNodes)
                {
                    IList ListInstance = null;
                    foreach (XmlNode _node in node.ChildNodes)
                    {
                        if (HasProperty(_node.Name))
                        {
                            var prop = this.GetType().GetProperty(_node.Name);

                            var teste = this.GetType().GetProperty(_node.Name).GetValue(this);
                            dynamic ret = null;
                            if (IsField(prop.PropertyType, _node.InnerText, out ret))
                            {

                                prop.SetValue(this, ret);
                            }
                            if (prop.GetValue(this) == null & prop.PropertyType.Name != "ICollection`1")
                            {
                                var instance = Activator.CreateInstance(prop.PropertyType);
                                object[] parameters = new object[1] { _node };
                                instance.GetType().GetMethod("SetProperties").Invoke(instance, parameters);
                                prop.SetValue(this, instance);
                            }
                            else if (prop.PropertyType.Name == "ICollection`1")
                            {
                                var instance = Activator.CreateInstance(prop.PropertyType.GenericTypeArguments[0]);
                                object[] parameters = new object[1] { _node };
                                instance.GetType().GetMethod("SetProperties").Invoke(instance, parameters);

                                if (ListInstance == null || ListInstance.GetType().GenericTypeArguments[0].Name != prop.Name)
                                {
                                    var ICollectionType = typeof(List<>);
                                    var ICollection = ICollectionType.MakeGenericType(prop.PropertyType.GenericTypeArguments);
                                    ListInstance = (IList)Activator.CreateInstance(ICollection);
                                }

                                ListInstance.Add(instance);

                                prop.SetValue(this, ListInstance);

                            }
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {

            }
            catch (NotSupportedException e)
            {

            }
            catch (Exception e)
            {
                throw new Exception($"{this.GetType().Name} {e.ToString()}");
            }
        }

        private bool HasProperty(string propertyName)
        {
            return this.GetType().GetProperty(propertyName) != null;
        }

        private bool IsField(Type prop, string Converter, out dynamic result)
        {
            result = null;
            bool retorno = false;
            string name = (prop.BaseType != null) ? ((prop.BaseType.Name == "Enum") ? "Enum" : prop.Name) : prop.Name;

            switch (name)
            {
                case "Int32":
                    {
                        int vl = 0;
                        Int32.TryParse(Converter, out vl);
                        result = vl;
                        retorno = true;
                    }
                    break;
                case "DateTime":
                    {
                        DateTime vl = new DateTime();
                        DateTime.TryParse(Converter, out vl);
                        result = vl;
                        retorno = true;
                    }
                    break;
                case "Byte":
                    {
                        Byte vl = 0;
                        Byte.TryParse(Converter, out vl);
                        result = vl;
                        retorno = true;
                    }
                    break;
                case "String":
                    {
                        result = Converter;
                        retorno = true;
                    }
                    break;
                case "Double":
                    {
                        double vl = 0;
                        double.TryParse(Converter.Replace(".", ","), out vl);
                        result = vl;
                        retorno = true;
                    }
                    break;
                case "Enum":
                    {
                        result = Enum.Parse(prop, Converter);
                        retorno = true;
                    }
                    break;
            }
            return retorno;
        }
    }
}
