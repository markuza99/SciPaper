// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/greet.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace UserMicroservice {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class Greeter
  {
    static readonly string __ServiceName = "Greeter";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::UserMicroservice.isLoggedInRequest> __Marshaller_isLoggedInRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserMicroservice.isLoggedInRequest.Parser));
    static readonly grpc::Marshaller<global::UserMicroservice.isLoggedInResponse> __Marshaller_isLoggedInResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserMicroservice.isLoggedInResponse.Parser));
    static readonly grpc::Marshaller<global::UserMicroservice.getNameRequest> __Marshaller_getNameRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserMicroservice.getNameRequest.Parser));
    static readonly grpc::Marshaller<global::UserMicroservice.getNameResponse> __Marshaller_getNameResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserMicroservice.getNameResponse.Parser));

    static readonly grpc::Method<global::UserMicroservice.isLoggedInRequest, global::UserMicroservice.isLoggedInResponse> __Method_CheckLogin = new grpc::Method<global::UserMicroservice.isLoggedInRequest, global::UserMicroservice.isLoggedInResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckLogin",
        __Marshaller_isLoggedInRequest,
        __Marshaller_isLoggedInResponse);

    static readonly grpc::Method<global::UserMicroservice.getNameRequest, global::UserMicroservice.getNameResponse> __Method_GetName = new grpc::Method<global::UserMicroservice.getNameRequest, global::UserMicroservice.getNameResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetName",
        __Marshaller_getNameRequest,
        __Marshaller_getNameResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::UserMicroservice.GreetReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Greeter</summary>
    [grpc::BindServiceMethod(typeof(Greeter), "BindService")]
    public abstract partial class GreeterBase
    {
      public virtual global::System.Threading.Tasks.Task<global::UserMicroservice.isLoggedInResponse> CheckLogin(global::UserMicroservice.isLoggedInRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::UserMicroservice.getNameResponse> GetName(global::UserMicroservice.getNameRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(GreeterBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CheckLogin, serviceImpl.CheckLogin)
          .AddMethod(__Method_GetName, serviceImpl.GetName).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, GreeterBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CheckLogin, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::UserMicroservice.isLoggedInRequest, global::UserMicroservice.isLoggedInResponse>(serviceImpl.CheckLogin));
      serviceBinder.AddMethod(__Method_GetName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::UserMicroservice.getNameRequest, global::UserMicroservice.getNameResponse>(serviceImpl.GetName));
    }

  }
}
#endregion
