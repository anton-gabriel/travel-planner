// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: communication.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Generated {
  public static partial class CommunicationService
  {
    static readonly string __ServiceName = "CommunicationService";

    static readonly grpc::Marshaller<global::Generated.UserRequest> __Marshaller_UserRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Generated.UserRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Generated.Response> __Marshaller_Response = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Generated.Response.Parser.ParseFrom);

    static readonly grpc::Method<global::Generated.UserRequest, global::Generated.Response> __Method_Communicate = new grpc::Method<global::Generated.UserRequest, global::Generated.Response>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "Communicate",
        __Marshaller_UserRequest,
        __Marshaller_Response);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Generated.CommunicationReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CommunicationService</summary>
    [grpc::BindServiceMethod(typeof(CommunicationService), "BindService")]
    public abstract partial class CommunicationServiceBase
    {
      public virtual global::System.Threading.Tasks.Task Communicate(grpc::IAsyncStreamReader<global::Generated.UserRequest> requestStream, grpc::IServerStreamWriter<global::Generated.Response> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CommunicationService</summary>
    public partial class CommunicationServiceClient : grpc::ClientBase<CommunicationServiceClient>
    {
      /// <summary>Creates a new client for CommunicationService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public CommunicationServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CommunicationService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public CommunicationServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected CommunicationServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected CommunicationServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncDuplexStreamingCall<global::Generated.UserRequest, global::Generated.Response> Communicate(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Communicate(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::Generated.UserRequest, global::Generated.Response> Communicate(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_Communicate, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override CommunicationServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CommunicationServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CommunicationServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Communicate, serviceImpl.Communicate).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CommunicationServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Communicate, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::Generated.UserRequest, global::Generated.Response>(serviceImpl.Communicate));
    }

  }
}
#endregion
