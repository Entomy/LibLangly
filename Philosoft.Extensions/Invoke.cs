using System.Traits;

namespace System {
	public static partial class TraitExtensions {
		/// <summary>
		/// Invokes the next <see cref="Action"/> in the queue.
		/// </summary>
		/// <param name="queue">This queue.</param>
		public static void Invoke(this IDequeue<Action> queue) => queue.Dequeue()?.Invoke();

		/// <summary>
		/// Invokes the next <see cref="Action{T}"/> in the queue.
		/// </summary>
		/// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="obj">The parameter of the method that this delegate encapsulates.</param>
		public static void Invoke<T>(this IDequeue<Action<T>> queue, T obj) => queue.Dequeue()?.Invoke(obj);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		public static void Invoke<T1, T2>(this IDequeue<Action<T1, T2>> queue, T1 arg1, T2 arg2) => queue.Dequeue()?.Invoke(arg1, arg2);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		public static void Invoke<T1, T2, T3>(this IDequeue<Action<T1, T2, T3>> queue, T1 arg1, T2 arg2, T3 arg3) => queue.Dequeue()?.Invoke(arg1, arg2, arg3);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4>(this IDequeue<Action<T1, T2, T3, T4>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5>(this IDequeue<Action<T1, T2, T3, T4, T5>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6>(this IDequeue<Action<T1, T2, T3, T4, T5, T6>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg9">The ninth paramter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T10">The type of the tenth paramter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg9">The ninth paramter of the argument that this delegate encapsulates.</param>
		/// <param name="arg10">The tenth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T10">The type of the tenth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg9">The ninth paramter of the argument that this delegate encapsulates.</param>
		/// <param name="arg10">The tenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg11">The eleventh parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T10">The type of the tenth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T12">The type of the twelvth paramter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg9">The ninth paramter of the argument that this delegate encapsulates.</param>
		/// <param name="arg10">The tenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg11">The eleventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg12">The twelvth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T10">The type of the tenth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T12">The type of the twelvth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg9">The ninth paramter of the argument that this delegate encapsulates.</param>
		/// <param name="arg10">The tenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg11">The eleventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg12">The twelvth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg13">The thirteenth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T10">The type of the tenth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T12">The type of the twelvth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg9">The ninth paramter of the argument that this delegate encapsulates.</param>
		/// <param name="arg10">The tenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg11">The eleventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg12">The twelvth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg13">The thirteenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg14">The fourteenth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T10">The type of the tenth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T12">The type of the twelvth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg9">The ninth paramter of the argument that this delegate encapsulates.</param>
		/// <param name="arg10">The tenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg11">The eleventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg12">The twelvth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg13">The thirteenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg14">The fourteenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg15">The fifteenth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);

		/// <summary>
		/// Invokes the next <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16}"/> in the queue.
		/// </summary>
		/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T10">The type of the tenth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T12">The type of the twelvth paramter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <typeparam name="T16">The type of the sixteenth parameter of the method that this delegate encapsulates.</typeparam>
		/// <param name="queue">This queue.</param>
		/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg3">The third parameter of the method that this delegate encapsultates.</param>
		/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
		/// <param name="arg5">The fifth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg6">The sixth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg7">The seventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg8">The eighth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg9">The ninth paramter of the argument that this delegate encapsulates.</param>
		/// <param name="arg10">The tenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg11">The eleventh parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg12">The twelvth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg13">The thirteenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg14">The fourteenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg15">The fifteenth parameter of the argument that this delegate encapsulates.</param>
		/// <param name="arg16">The sixteenth parameter of the argument that this delegate encapsulates.</param>
		public static void Invoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IDequeue<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> queue, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) => queue.Dequeue()?.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
	}
}
