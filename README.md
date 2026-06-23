# 2D RPG for Toge Productions Hiring Process

# ToDo List
+ Building blocks
  - [x] movement
  - [x] interact
  - [x] dialogue system
  - [ ] turn-based fighting 
  - [ ] mini game after choosing the fight action
  - [ ] agility to determine who's turn
  - [ ] status / resources components with Scriptable object as data container
  - [ ] cutscene system

+ Important
  - [x] refactor scripts and folders before submit
  
+ Bugs
 - [ ] interact input on Interact class and next dialogue input on DialougeManager class are conflict. need to enable it one at a time.
  
## Notes
- Do every character behavior as components, so it can be reusable
- Implement first, refactor/design pattern later

- Behavior class for interactable object. Have Init, Process, and Exit.
- Behavior class handling dialogue, destroying object, and fighting entry point.
- This class is required for Interactable class
- Behavior class entry point called Execute()
- Behavior class unique for every character

- for Fighting, it had its own class.
- also unique for every character 
- handling FightingComponent ( health, attack, defense, parrying. These components have its own animation. All of its data read from ScriptableObject )
- Every AttackComponent have damage type to handle multiple target, single target, or Area.
- this Fighting class handled by TurnBasedManager to handle order execution order.
- Defense is 
 
## Reference
- https://drive.google.com/drive/u/0/folders/11J5vShihLFjVLxovskhCtU-V4Azfdt5j
- https://drive.google.com/file/d/1vTxKee1hKu1dmJFziajId98IFudghgQD/view?usp=sharing
