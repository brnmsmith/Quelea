﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Grasshopper.Kernel;
using RS = Agent.Properties.Resources;

namespace Agent
{
  public abstract class AbstractBoidForceComponent : AbstractForceComponent
  {
    protected SpatialCollectionType neighborsCollection;
    protected List<AgentType> neighbors; 
    /// <summary>
    /// Initializes a new instance of the ViewForceComponent class.
    /// </summary>
    protected AbstractBoidForceComponent(string name, string nickname, string description, 
                              string category, string subCategory, Bitmap icon, String componentGuid)
      : base(name, nickname, description, category, subCategory, icon, componentGuid)
    {
      neighborsCollection = new SpatialCollectionType();
    }

    /// <summary>
    /// Registers all the input parameters for this component.
    /// </summary>
    protected override void RegisterInputParams(GH_InputParamManager pManager)
    {
      base.RegisterInputParams(pManager);
      pManager.AddGenericParameter(RS.neighborsName, RS.agentCollectionNickName, RS.neighborsToReactTo, GH_ParamAccess.item);
    }

    protected override bool GetInputs(IGH_DataAccess da)
    {
      if(!base.GetInputs(da)) return false;

      if (!da.GetData(nextInputIndex++, ref neighborsCollection)) return false;
      neighbors = (List<AgentType>) neighborsCollection.Agents.SpatialObjects;
      return true;
    }
  }
}