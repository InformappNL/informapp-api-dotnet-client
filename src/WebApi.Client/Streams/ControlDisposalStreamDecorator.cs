using System.IO;

namespace ConnectedDevelopment.InformSystem.WebApi.Client.Streams
{
    internal class ControlDisposalStreamDecorator : StreamDecoratorBase<ControlDisposalStreamDecorator>
    {
        public bool LeaveOpen { get; }

        public ControlDisposalStreamDecorator(Stream stream, bool leaveOpen) : base(stream)
        {
            LeaveOpen = leaveOpen;
        }

        protected override void Dispose(bool disposing)
        {
            if (LeaveOpen == false)
            {
                base.Dispose(disposing);
            }
        }

        public override void Close()
        {
            if (LeaveOpen == false)
            {
                base.Close();
            }
        }

        public override bool Equals(ControlDisposalStreamDecorator other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (LeaveOpen == other.LeaveOpen && Stream.Equals(other.Stream))
            {
                return true;
            }

            return false;
        }
    }
}
