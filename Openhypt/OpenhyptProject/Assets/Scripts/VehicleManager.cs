using UnityEngine;
using System.Collections;

public enum VMState
{
    CreateInstance = 0,
    DuplicateInstance = 1,
    HoldInstance = 2
}

[System.Serializable]
public partial class VehicleManager : MonoBehaviour/*, UnityScript.Scripting.IEvaluationDomainProvider*/
{
    public static VehicleManager instance;
    public virtual void Awake()
    {
        UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
        switch (this.GetCurrentCircumstances())
        {
            case VMState.CreateInstance:
                VehicleManager.instance = this;
                break;
            case VMState.DuplicateInstance:
                UnityEngine.Object.Destroy(this.gameObject);
                break;
        }
    }

    public virtual void Start()
    {
        //string _path = Boo.Lang.Runtime.RuntimeServices.op_Addition(SaveInfo.GetAppData(), "/Zerahypt/Initializer.ini");
        //string data = System.IO.File.ReadAllText($463._path);
        //string _path = SaveInfo.GetAppData() + "/Zerahypt/Initializer.ini";
        //if (System.IO.File.Exists(_path))
        //{
        //    string data = System.IO.File.ReadAllText(_path);
        //    if (data.Length > 0)
        //    {
        //        UnityScript.Scripting.Evaluator.Eval($463, data);
        //    }
        //}
    }

    public static void EnterVehicle(MainVehicleController _vehicle, CarDoorController _door)
    {
        WorldInformation.vehicleDoorController = _door;
        WorldInformation.vehicleController = _vehicle;
        WorldInformation.vehicleController.Update2();
    }

    public static void ExitVehicle()
    {
        WorldInformation.vehicleController.Update2();
        WorldInformation.vehicleDoorController = null;
        WorldInformation.vehicleController = null;
    }

    public virtual VMState GetCurrentCircumstances()
    {
        if (VehicleManager.instance == null)
        {
            return VMState.CreateInstance;
        }
        else
        {
            if (VehicleManager.instance == this)
            {
                return VMState.HoldInstance;
            }
            else
            {
                return VMState.DuplicateInstance;
            }
        }
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((((!Input.GetMouseButton(1) && !FurtherActionScript.IsActive) && !TalkScript.isTyping) && !WorldInformation.isHolding) && !WorldInformation.PiriIsHurt)
            {
                if (WorldInformation.vehicleDoorController != null)
                {
                    if (!WorldInformation.vehicleDoorController.inVehicle)
                    {
                        if (WorldInformation.vehicleDoorController.nearVehicle)
                        {
                            WorldInformation.vehicleDoorController.Enter();
                        }
                    }
                    else
                    {
                        if (WorldInformation.CanLeaveVehicle)
                        {
                            this.StartCoroutine(WorldInformation.vehicleDoorController.Exit());
                        }
                    }
                }
            }
        }
        if (WorldInformation.vehicleController != null)
        {
            WorldInformation.vehicleController.ArtificialUpdate();
            if (WorldInformation.vehicleDoorController != null)
            {
                WorldInformation.vehicleDoorController.ArtificialUpdate();
            }
        }
    }
    /*
    private UnityScript.Scripting.EvaluationDomain domain464;
    public virtual UnityScript.Scripting.EvaluationDomain GetEvaluationDomain()
    {
        return (this.domain464 != null) || (this.domain464 = new UnityScript.Scripting.EvaluationDomain() != null);
    }

    public virtual string[] GetImports()
    {
        return new string[] {"UnityEngine", "UnityEditor", "System.Collections"};
    }

    public virtual System.Reflection.Assembly[] GetAssemblyReferences()
    {
        return EvalAssemblyReferences.Value;
    }
    */
}