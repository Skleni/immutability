using System;
using System.Collections;
using System.Collections.Generic;

namespace Immutability
{
    public class ImmutableStack<T> : IEnumerable<T>
    {
        public static ImmutableStack<T> Empty { get; } = new ImmutableStack<T>(default, null);

        private readonly T head;
        private readonly ImmutableStack<T> tail;

        private ImmutableStack(T head, ImmutableStack<T> tail)
        {
            this.head = head;
            this.tail = tail;
        }

        public bool IsEmpty => this.tail == null;

        public ImmutableStack<T> Push(T value)
        {
            return new ImmutableStack<T>(value, this);
        }

        public ImmutableStack<T> Pop()
        {
            this.EnsureNotEmpty();
            return this.tail;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this.head;
        }

        private void EnsureNotEmpty()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = this; current != null; current = current.tail)
            {
                yield return current.head;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
