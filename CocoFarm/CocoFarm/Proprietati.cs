using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CocoFarm.Models
{
    public class Proprietati : ICollection<ProprietateValoare>
    {
        private static readonly List<ProprietateValoare> listaProprietati = new List<ProprietateValoare>();

        public void Add(ProprietateValoare item)
        {
            listaProprietati.Add(item);
        }

        public void Clear()
        {
            listaProprietati.Clear();
        }

        public bool Contains(ProprietateValoare item)
        {
            return listaProprietati.Contains(item);
        }

        public void CopyTo(ProprietateValoare[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(ProprietateValoare item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ProprietateValoare> GetEnumerator()
        {
            return listaProprietati.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return listaProprietati.GetEnumerator();
        }
    }
}