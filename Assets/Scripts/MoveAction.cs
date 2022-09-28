using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{

    //[SerializeField] private Animator unitAnimator;
    [SerializeField] private int maxMoveDistance = 4;
    [SerializeField] private int type = 0;

    private Vector3 targetPosition;
    private Unit unit;


    private void Awake()
    {
        unit = GetComponent<Unit>();
        targetPosition = transform.position;
    }

    private void Update()
    {
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            // float rotateSpeed = 10f;
            // transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

            //unitAnimator.SetBool("IsWalking", true);
        }
        // else
        // {
        //     unitAnimator.SetBool("IsWalking", false);
        // }

    }


    public void Move(GridPosition gridPosition)
    {
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }

    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }

   public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();

        if(type == 0){
          
                for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
                {
                    for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
                    {
                        GridPosition offsetGridPosition = new GridPosition(x, z);
                        GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                        if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                        {
                            continue;
                        }

                        if (unitGridPosition == testGridPosition)
                        {
                            // Same Grid Position where the unit is already at
                            continue;
                        }

                        if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                        {
                            // Grid Position already occupied with another Unit
                            continue;
                        }

                        validGridPositionList.Add(testGridPosition);
                    }
                }     

        }else{

            if(type == 1){

                for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
                {
                    for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
                    {

                        GridPosition offsetGridPosition = new GridPosition(x, z);
                        GridPosition testGridPosition = unitGridPosition + offsetGridPosition;


                        if(x == -4){
                            offsetGridPosition = new GridPosition(-1, 2);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }

                        if(x == -3){
                            offsetGridPosition = new GridPosition(-1, -2);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }

                        if(x == -2){
                            offsetGridPosition = new GridPosition(-2, 1);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }

                        if(x == -1){
                            offsetGridPosition = new GridPosition(-2, -1);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }

                        if(x == 0){
                            offsetGridPosition = new GridPosition(0, 0);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }

                        if(x == 1){
                            offsetGridPosition = new GridPosition(1, 2);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }

                        if(x == 2){
                            offsetGridPosition = new GridPosition(1, -2);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }

                        if(x == 3){
                            offsetGridPosition = new GridPosition(2, 1);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }

                        if(x == 4){
                            offsetGridPosition = new GridPosition(2, -1);
                            testGridPosition = unitGridPosition + offsetGridPosition;
                        }   
                    
                        if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                        {
                            continue;
                        }

                        if (unitGridPosition == testGridPosition)
                        {
                            // Same Grid Position where the unit is already at
                            continue;
                        }

                        if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                        {
                            // Grid Position already occupied with another Unit
                            continue;
                        }

                        validGridPositionList.Add(testGridPosition);            
                    }

                }
            }else{
                if(type == 2){

                    for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
                    {
                        GridPosition offsetGridPosition = new GridPosition(0, x);
                        GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                        if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                        {
                            continue;
                        }

                        if (unitGridPosition == testGridPosition)
                        {
                            // Same Grid Position where the unit is already at
                            continue;
                        }

                        if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                        {
                            // Grid Position already occupied with another Unit
                            continue;
                        }

                        validGridPositionList.Add(testGridPosition);
                    }
                }else{
                    if(type == 3){

                        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
                    {
                        GridPosition offsetGridPosition = new GridPosition(x, x);
                        GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                        if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                        {
                            continue;
                        }

                        if (unitGridPosition == testGridPosition)
                        {
                            // Same Grid Position where the unit is already at
                            continue;
                        }

                        if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                        {
                            // Grid Position already occupied with another Unit
                            continue;
                        }

                        validGridPositionList.Add(testGridPosition);
                    }

                    for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
                    {
                        GridPosition offsetGridPosition = new GridPosition(-x, x);
                        GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                        if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                        {
                            continue;
                        }

                        if (unitGridPosition == testGridPosition)
                        {
                            // Same Grid Position where the unit is already at
                            continue;
                        }

                        if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                        {
                            // Grid Position already occupied with another Unit
                            continue;
                        }

                        validGridPositionList.Add(testGridPosition);
                    }
                }
            }   
        }          

    }

        return validGridPositionList;
    }

}