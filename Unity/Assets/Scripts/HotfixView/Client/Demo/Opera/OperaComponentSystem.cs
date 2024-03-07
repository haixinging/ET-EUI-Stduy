using System;
using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof(OperaComponent))]
    [FriendOf(typeof(OperaComponent))]
    public static partial class OperaComponentSystem
    {
        [EntitySystem]
        private static void Awake(this OperaComponent self)
        {
            self.mapMask = LayerMask.GetMask("Map");
        }

        [EntitySystem]
        private static void Update(this OperaComponent self)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, self.mapMask))
                {
                    C2M_PathfindingResult c2MPathfindingResult = new C2M_PathfindingResult();
                    c2MPathfindingResult.Position = hit.point;
                    self.Root().GetComponent<ClientSenderCompnent>().Send(c2MPathfindingResult);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                CodeLoader.Instance.Reload();
                return;
            }
        
            if (Input.GetKeyDown(KeyCode.T))
            {
                C2M_TransferMap c2MTransferMap = new();
                self.Root().GetComponent<ClientSenderCompnent>().Call(c2MTransferMap).Coroutine();
            }

            if (Input.GetKey(KeyCode.W))
            {
                UnitComponent unitComponent = self.GetParent<Scene>().GetComponent<UnitComponent>();
                Unit unit = unitComponent.GetChild<Unit>(unitComponent.CurrentUnitId);
                unit.GetComponent<MoveComponent>().MoveTo(new float3(0,0,1), 0.01f);
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                UnitComponent unitComponent = self.GetParent<Scene>().GetComponent<UnitComponent>();
                Unit unit = unitComponent.GetChild<Unit>(unitComponent.CurrentUnitId);
                unit.GetComponent<MoveComponent>().MoveTo(new float3(0,0,-1), 0.01f);
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                UnitComponent unitComponent = self.GetParent<Scene>().GetComponent<UnitComponent>();
                Unit unit = unitComponent.GetChild<Unit>(unitComponent.CurrentUnitId);
                unit.GetComponent<MoveComponent>().MoveTo(new float3(-1,0,0), 0.01f);
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                UnitComponent unitComponent = self.GetParent<Scene>().GetComponent<UnitComponent>();
                Unit unit = unitComponent.GetChild<Unit>(unitComponent.CurrentUnitId);
                unit.GetComponent<MoveComponent>().MoveTo(new float3(1,0,0), 0.01f);
            }
        }
    }
}