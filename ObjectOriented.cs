namespace ObjectOriented;

using System.Collections.Generic;

interface IValuable {
  int Value();
}

sealed record Man(int strength, int stamina):  IValuable {
  public int Value() => strength * stamina;
}
sealed record Elf(int age, int magic): IValuable {
  public int Value() => age * magic * 2;
}
sealed record Dwarf(int will): IValuable {
  public int Value() => will * 10;
}

sealed class WarSystem {
  List<IValuable> army = new ();

  public WarSystem(int soldiers) {
    for(int i = 0; i < soldiers / 3; i++) army.Add(new Man(1,1));
    for(int i = 0; i < soldiers / 3; i++) army.Add(new Elf(1,1));
    for(int i = 0; i < soldiers / 3; i++) army.Add(new Dwarf(1));
  }

  public int ValueArmy() => army.Sum(s => s.Value());
}
