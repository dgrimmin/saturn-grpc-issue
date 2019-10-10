namespace Shared

open System.ServiceModel
open System.Threading.Tasks
open System.Runtime.Serialization

[<DataContract; CLIMutable>]
type MultiplyRequest =
    { [<DataMember(Order = 1)>] X : list<float>
      [<DataMember(Order = 2)>] Y : list<float> }

[<DataContract; CLIMutable>]
type MultiplyResult =
    { [<DataMember(Order = 1)>] Result : list<float> }

[<ServiceContract(Name = "Hyper.Calculator")>]
type ICalculator =
    abstract MultiplyAsync : MultiplyRequest -> ValueTask<MultiplyResult>