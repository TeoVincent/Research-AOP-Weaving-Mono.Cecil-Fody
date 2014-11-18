using System;

namespace TeoVincent.AssemblyToProcess.Events
{
    public abstract partial class AEvent : EventArgs
    {
        private string strChildType;
        private DateTime dtWhen;
        private Guid id;

        public string ChildType
        {
            get { return strChildType; }
            set { strChildType = value; }
        }

        public DateTime When
        {
            get { return dtWhen; }
            set { dtWhen = value; }
        }

        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        protected AEvent(string strChildType)
            : this(strChildType, DateTime.Now)
        { }

        private AEvent(string strChildType, DateTime dtWhen)
        {
            this.strChildType = strChildType;
            this.dtWhen = dtWhen;
            id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if ((obj is AEvent) == false)
                return false;

            return Equals((AEvent)obj);
        }

        public bool Equals(AEvent other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (ChildType != other.ChildType)
                return false;

            return other.id.Equals(id);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("(EVENT={0}; WHEN={1}.{2}; ID={3})", ChildType, When, When.Millisecond, ID);
        }
    }
}