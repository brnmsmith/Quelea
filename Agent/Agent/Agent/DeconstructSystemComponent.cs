﻿using System;
using System.Collections.Generic;
using RS = Agent.Properties.Resources;
using Grasshopper.Kernel;

namespace Agent
{
  public class DeconstructSystemComponent : GH_Component
  {
    /// <summary>
    /// Initializes a new instance of the DecomposeAgent class.
    /// </summary>
    public DeconstructSystemComponent()
      : base(RS.deconstructSystemName, RS.deconstructSystemNickName,
          RS.deconstructSystemDescription,
          RS.pluginCategoryName, RS.pluginSubCategoryName)
    {
    }

    /// <summary>
    /// Registers all the input parameters for this component.
    /// </summary>
    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
      pManager.AddGenericParameter(RS.systemName, RS.systemNickName, RS.systemDescription, GH_ParamAccess.item);
    }

    /// <summary>
    /// Registers all the output parameters for this component.
    /// </summary>
    protected override void RegisterOutputParams(GH_OutputParamManager pManager)
    {
      pManager.AddGenericParameter(RS.agentsName, RS.agentNickName, RS.agentDescription, GH_ParamAccess.list);
      pManager.AddGenericParameter(RS.agentCollectionName, RS.agentCollectionNickName, RS.agentCollectionDescription, GH_ParamAccess.item);
    }

    /// <summary>
    /// This is the method that actually does the work.
    /// </summary>
    /// <param name="da">The DA object is used to retrieve from inputs and store in outputs.</param>
    protected override void SolveInstance(IGH_DataAccess da)
    {
      // First, we need to retrieve all data from the input parameters.
      // We'll start by declaring variables and assigning them starting values.
      AgentSystemType system = new AgentSystemType();

      // Then we need to access the input parameters individually. 
      // When data cannot be extracted from a parameter, we should abort this method.
      if (!da.GetData(0, ref system)) return;

      // We should now validate the data and warn the user if invalid data is supplied.

      // We're set to create the output now. To keep the size of the SolveInstance() method small, 
      // The actual functionality will be in a different method:

      // Finally assign the spiral to the output parameter.
      da.SetDataList(0, (List<AgentType>) system.Agents.SpatialObjects);
      da.SetData(1, new SpatialCollectionType(system.Agents));
    }

    /// <summary>
    /// Provides an Icon for the component.
    /// </summary>
    protected override System.Drawing.Bitmap Icon
    {
      get
      {
        //You can add image files to your project resources and access them like this:
        // return Resources.IconForThisComponent;
        return Properties.Resources.icon_deconstructSystem;
      }
    }

    /// <summary>
    /// Gets the unique ID for this component. Do not change this ID after release.
    /// </summary>
    public override Guid ComponentGuid
    {
      get { return new Guid(RS.deconstructSystemGUID); }
    }
  }
}