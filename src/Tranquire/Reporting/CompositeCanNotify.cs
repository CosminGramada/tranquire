﻿using System.Linq;

namespace Tranquire.Reporting
{
    /// <summary>
    /// A composite implementation of <see cref="ICanNotify"/>, where the action or question can send a notifiy only if all the inner <see cref="ICanNotify"/> returns true
    /// </summary>
    public class CompositeCanNotify : ICanNotify
    {
        private readonly ICanNotify[] _innerCanNotify;

        /// <summary>
        /// Creates a new instance of <see cref="CompositeCanNotify"/>
        /// </summary>
        /// <param name="innerCanNotify"></param>
        public CompositeCanNotify(params ICanNotify[] innerCanNotify)
        {
            Guard.ForNull(innerCanNotify, nameof(innerCanNotify));
            _innerCanNotify = innerCanNotify;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS0618 // Type or member is obsolete
        public bool Action<TGivenAbility, TWhenAbility, TResult>(IAction<TGivenAbility, TWhenAbility, TResult> action) => _innerCanNotify.All(c => c.Action(action));
#pragma warning restore CS0618 // Type or member is obsolete
        public bool Action<TResult>(IAction<TResult> action) => _innerCanNotify.All(c => c.Action(action));
        public bool Question<TAbility, TResult>(IQuestion<TAbility, TResult> question) => _innerCanNotify.All(c => c.Question(question));
        public bool Question<TResult>(IQuestion<TResult> question) => _innerCanNotify.All(c => c.Question(question));
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
