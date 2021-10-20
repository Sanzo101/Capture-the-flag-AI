using System.Collections.Generic;
using UnityEngine;

/*****************************************************************************************************************************
 * Write your core AI code in this file here. The private variable 'agentScript' contains all the agents actions which are listed
 * below. Ensure your code it clear and organised and commented.
 *
 * Unity Tags
 * public static class Tags
 * public const string BlueTeam = "Blue Team";	The tag assigned to blue team members.
 * public const string RedTeam = "Red Team";	The tag assigned to red team members.
 * public const string Collectable = "Collectable";	The tag assigned to collectable items (health kit and power up).
 * public const string Flag = "Flag";	The tag assigned to the flags, blue or red.
 * 
 * Unity GameObject names
 * public static class Names
 * public const string PowerUp = "Power Up";	Power up name
 * public const string HealthKit = "Health Kit";	Health kit name.
 * public const string BlueFlag = "Blue Flag";	The blue teams flag name.
 * public const string RedFlag = "Red Flag";	The red teams flag name.
 * public const string RedBase = "Red Base";    The red teams base name.
 * public const string BlueBase = "Blue Base";  The blue teams base name.
 * public const string BlueTeamMember1 = "Blue Team Member 1";	Blue team member 1 name.
 * public const string BlueTeamMember2 = "Blue Team Member 2";	Blue team member 2 name.
 * public const string BlueTeamMember3 = "Blue Team Member 3";	Blue team member 3 name.
 * public const string RedTeamMember1 = "Red Team Member 1";	Red team member 1 name.
 * public const string RedTeamMember2 = "Red Team Member 2";	Red team member 2 name.
 * public const string RedTeamMember3 = "Red Team Member 3";	Red team member 3 name.
 * 
 * _agentData properties and public variables
 * public bool IsPoweredUp;	Have we powered up, true if we’re powered up, false otherwise.
 * public int CurrentHitPoints;	Our current hit points as an integer
 * public bool HasFriendlyFlag;	True if we have collected our own flag
 * public bool HasEnemyFlag;	True if we have collected the enemy flag
 * public GameObject FriendlyBase; The friendly base GameObject
 * public GameObject EnemyBase;    The enemy base GameObject
 * public int FriendlyScore; The friendly teams score
 * public int EnemyScore;       The enemy teams score
 * 
 * _agentActions methods
 * public bool MoveTo(GameObject target)	Move towards a target object. Takes a GameObject representing the target object as a parameter. Returns true if the location is on the navmesh, false otherwise.
 * public bool MoveTo(Vector3 target)	Move towards a target location. Takes a Vector3 representing the destination as a parameter. Returns true if the location is on the navmesh, false otherwise.
 * public bool MoveToRandomLocation()	Move to a random location on the level, returns true if the location is on the navmesh, false otherwise.
 * public void CollectItem(GameObject item)	Pick up an item from the level which is within reach of the agent and put it in the inventory. Takes a GameObject representing the item as a parameter.
 * public void DropItem(GameObject item)	Drop an inventory item or the flag at the agents’ location. Takes a GameObject representing the item as a parameter.
 * public void UseItem(GameObject item)	Use an item in the inventory (currently only health kit or power up). Takes a GameObject representing the item to use as a parameter.
 * public void AttackEnemy(GameObject enemy)	Attack the enemy if they are close enough. ). Takes a GameObject representing the enemy as a parameter.
 * public void Flee(GameObject enemy)	Move in the opposite direction to the enemy. Takes a GameObject representing the enemy as a parameter.
 * 
 * _agentSenses properties and methods
 * public List<GameObject> GetObjectsInViewByTag(string tag)	Return a list of objects with the same tag. Takes a string representing the Unity tag. Returns null if no objects with the specified tag are in view.
 * public GameObject GetObjectInViewByName(string name)	Returns a specific GameObject by name in view range. Takes a string representing the objects Unity name as a parameter. Returns null if named object is not in view.
 * public List<GameObject> GetObjectsInView()	Returns a list of objects within view range. Returns null if no objects are in view.
 * public List<GameObject> GetCollectablesInView()	Returns a list of objects with the tag Collectable within view range. Returns null if no collectable objects are in view.
 * public List<GameObject> GetFriendliesInView()	Returns a list of friendly team AI agents within view range. Returns null if no friendlies are in view.
 * public List<GameObject> GetEnemiesInView()	Returns a list of enemy team AI agents within view range. Returns null if no enemy are in view.
 * public bool IsItemInReach(GameObject item)	Checks if we are close enough to a specific collectible item to pick it up), returns true if the object is close enough, false otherwise.
 * public bool IsInAttackRange(GameObject target)	Check if we're with attacking range of the target), returns true if the target is in range, false otherwise.
 * 
 * _agentInventory properties and methods
 * public bool AddItem(GameObject item)	Adds an item to the inventory if there's enough room (max capacity is 'Constants.InventorySize'), returns true if the item has been successfully added to the inventory, false otherwise.
 * public GameObject GetItem(string itemName)	Retrieves an item from the inventory as a GameObject, returns null if the item is not in the inventory.
 * public bool HasItem(string itemName)	Checks if an item is stored in the inventory, returns true if the item is in the inventory, false otherwise.
 * 
 * You can use the game objects name to access a GameObject from the sensing system. Thereafter all methods require the GameObject as a parameter.
 * 
*****************************************************************************************************************************/

/// <summary>
/// Implement your AI script here, you can put everything in this file, or better still, break your code up into multiple files
/// and call your script here in the Update method. This class includes all the data members you need to control your AI agent
/// get information about the world, manage the AI inventory and access essential information about your AI.
///
/// You may use any AI algorithm you like, but please try to write your code properly and professionaly and don't use code obtained from
/// other sources, including the labs.
///
/// See the assessment brief for more details
/// </summary>
public class AI : MonoBehaviour
{
    // Gives access to important data about the AI agent (see above)
    private AgentData _agentData;
    // Gives access to the agent senses
    private Sensing _agentSenses;
    // gives access to the agents inventory
    private InventoryController _agentInventory;
    // This is the script containing the AI agents actions
    // e.g. agentScript.MoveTo(enemy);
    private AgentActions _agentActions;
    private Node topnode;
   


    //Public getters for use in actions and decisions
    #region Getters
    public AgentData GetAgentData() { return _agentData; }
    public Sensing GetAgentSenses() { return _agentSenses; }
    public AgentActions GetAgentActions() { return _agentActions; }

    public InventoryController GetAgentInventory() { return _agentInventory; }
    #endregion

    //Variables to allow AI targetting of enemies
    #region Targeting
    AI _target;
    public void SetTarget(AI target) { _target = target; }
    public AI GetTarget() { return _target; }
    #endregion
    // Use this for initialization
    void Start ()
    {
        // Initialise the accessable script components
        _agentData = GetComponent<AgentData>();
        _agentActions = GetComponent<AgentActions>();
        _agentSenses = GetComponentInChildren<Sensing>();
        _agentInventory = GetComponentInChildren<InventoryController>();
        ConstructBehaviourTree();


    }

    // Update is called once per frame
    void Update ()
    {
        // Run your AI code in here
        topnode.Evaluate();
        
    }
    private void ConstructBehaviourTree()
    {
        
        Attack attacknode = new Attack(this);
        HealthIsFine healthnode = new HealthIsFine(this);
        AttackCondition attackcondition = new AttackCondition(this);
        FlagCondition flagcondition = new FlagCondition(this);
        PickUpEnemyFlag PickUpEnemyFlagAction = new PickUpEnemyFlag(this);
        GetHealthPack GetHealthPackAction = new GetHealthPack(this);
        GoToTeamBase BringFlagHome = new GoToTeamBase(this);
        HealthPackAvailableCheck CheckForHealthPack = new HealthPackAvailableCheck(this);
        EnemyHaveYourFlagCondition CheckIfEnemyIsHoldingFlag = new EnemyHaveYourFlagCondition(this);
        DefenceHoldingFlagCondition DoIHaveEnemyFlag = new DefenceHoldingFlagCondition(this);
        PickUpTeamFlag PickupTeamFlagAction = new PickUpTeamFlag(this);
        PrioritiseAndAttackEnemyWithFlag PrioritiseEnemyAction = new PrioritiseAndAttackEnemyWithFlag(this);
        EnemyNotHoldingTeamFlagCondition EnemyNotHoldingTeamFlagCondition = new EnemyNotHoldingTeamFlagCondition(this);
        HasFriendlyFlagCondition Hasfriendlyflagcondition = new HasFriendlyFlagCondition(this);
        DoesNotHaveFriendlyFlagCondition doesNotHaveFriendlyFlagCondition = new DoesNotHaveFriendlyFlagCondition(this);
        IsEnemyflaginsight isEnemyFlagWithinReach = new IsEnemyflaginsight(this);
        DropFlagAction dropFriendlyFlag = new DropFlagAction(this);
        IsFriendlyFlagAtBase FriendlyFlagAtBaseCondition = new IsFriendlyFlagAtBase(this);
        IsEnemyflagNOTinsight EnemyFlagNotInSight = new IsEnemyflagNOTinsight(this);
        TeamHaveTeamFlagCondition TeamHaveTeamFlag = new TeamHaveTeamFlagCondition(this);
        IsFriendlyFlagNOTatBase TeamFlagIsAtBaseCheck = new IsFriendlyFlagNOTatBase(this);
        TeamDoesHaveTeamFlagCondition TeamHasTeamFlagCheck = new TeamDoesHaveTeamFlagCondition(this);
        TeamHaveEnemyFlagCondition TeamHaveEnemyFlagCheck = new TeamHaveEnemyFlagCondition(this);
        FollowTeamMateWithEnemyFlag FollowTeamWithEnemyFlagAction = new FollowTeamMateWithEnemyFlag(this);
        TeamDoesNotHaveEnemyFlagCondition TeamDontHaveEnemyFlagCheck = new TeamDoesNotHaveEnemyFlagCondition(this);
        IsAIAtBaseCondition AmIAtBase = new IsAIAtBaseCondition(this);
        IsAnyoneMovingTowardsHealthPackCondition MovingTowardsHealthPackCheck = new IsAnyoneMovingTowardsHealthPackCondition(this);
        isPowerUpWithingDecentRange PowerUpInAvailable = new isPowerUpWithingDecentRange(this);
        MoveToPowerUp GoToPowerUp = new MoveToPowerUp(this);


        Sequence GetPowerUpSequence = new Sequence(new List<Node> { PowerUpInAvailable, GoToPowerUp });
        Sequence PickedUpEnemyFlagSeuqence = new Sequence(new List<Node> {DoIHaveEnemyFlag, BringFlagHome});
        Sequence ImNotHoldingEnemyFlagSequence = new Sequence(new List<Node> {flagcondition, PickUpEnemyFlagAction});
        Selector ImHoldingEnemyFlagSelector = new Selector(new List<Node> {PickedUpEnemyFlagSeuqence, ImNotHoldingEnemyFlagSequence });
        Sequence TeamDoesNotHaveEnemyFlagSequence = new Sequence(new List<Node> {TeamDontHaveEnemyFlagCheck, ImHoldingEnemyFlagSelector });
        Sequence TeamDoesHaveEnemyFlagSequence = new Sequence(new List<Node> { TeamHaveEnemyFlagCheck, flagcondition, FollowTeamWithEnemyFlagAction });
        Selector GettingEnemyFlagSelector = new Selector(new List<Node> {TeamDoesHaveEnemyFlagSequence, TeamDoesNotHaveEnemyFlagSequence });
        Sequence TeamMatesHaveMyFlagSequence = new Sequence(new List<Node> {TeamHasTeamFlagCheck, GettingEnemyFlagSelector });
        Sequence EnemyDoesHaveTeamFlagSequence = new Sequence(new List<Node> {CheckIfEnemyIsHoldingFlag, PrioritiseEnemyAction});
        Sequence TeamFlagIsNotAtBaseSequence = new Sequence(new List<Node> {FriendlyFlagAtBaseCondition, BringFlagHome });
        Sequence TeamFlagIsAtBaseSequence = new Sequence(new List<Node> { TeamFlagIsAtBaseCheck, dropFriendlyFlag, GettingEnemyFlagSelector });
        Selector AtBaseSelector = new Selector(new List<Node> {TeamFlagIsAtBaseSequence, Hasfriendlyflagcondition, TeamFlagIsNotAtBaseSequence  });
        Sequence PickUpTeamFlagAndBringHomeSequence = new Sequence(new List<Node> {PickupTeamFlagAction, Hasfriendlyflagcondition, BringFlagHome, AtBaseSelector});
        Sequence EnemyDoesntNotHaveTeamFlagSequence = new Sequence(new List<Node> {EnemyNotHoldingTeamFlagCondition, TeamHaveTeamFlag, PickUpTeamFlagAndBringHomeSequence  });
        Selector EnemyHasYourFlagSelector = new Selector(new List<Node> {EnemyDoesntNotHaveTeamFlagSequence, EnemyDoesHaveTeamFlagSequence, TeamMatesHaveMyFlagSequence });
        Sequence EnemyFlagNOTinReachSequence = new Sequence(new List<Node> { EnemyFlagNotInSight, FriendlyFlagAtBaseCondition, EnemyHasYourFlagSelector });
        Sequence EnemyFlagIinReachSequence = new Sequence(new List<Node> { isEnemyFlagWithinReach, GettingEnemyFlagSelector });
        Selector EnemyFlagInReachSelector = new Selector(new List<Node> { EnemyFlagIinReachSequence, EnemyFlagNOTinReachSequence });
        Sequence SequenceForGettinTeamFlagBack = new Sequence(new List<Node> { flagcondition, EnemyFlagInReachSelector });
        Sequence attacknodesequence = new Sequence(new List<Node> { flagcondition, doesNotHaveFriendlyFlagCondition, attackcondition, attacknode });
        Sequence GettingHealthSequence = new Sequence(new List<Node> {CheckForHealthPack , GetHealthPackAction});
        //Selector HealthPackOrPowerUpSelector = new Selector(new List<Node> {GettingHealthSequence,GetPowerUpSequence });
        Sequence HealthSequence = new Sequence(new List<Node> { flagcondition, doesNotHaveFriendlyFlagCondition,healthnode, GettingHealthSequence/*HealthPackOrPowerUpSelector*/ /*MovingTowardsHealthPackCheck*/});
        Sequence SequenceforIfImholdingTeamFlag = new Sequence(new List<Node> {Hasfriendlyflagcondition, AmIAtBase, dropFriendlyFlag  });
        




       Selector Rootselector = new Selector(new List<Node> { HealthSequence, attacknodesequence,SequenceForGettinTeamFlagBack,SequenceforIfImholdingTeamFlag, GettingEnemyFlagSelector, PickedUpEnemyFlagSeuqence});

       Repeater RepeatTree = new Repeater(Rootselector);

       topnode = new Selector(new List<Node> { RepeatTree});
    }
}