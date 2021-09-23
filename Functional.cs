namespace Functional;

using System.Collections.Generic;

abstract record Valuable;
sealed record Man(int strength, int stamina): Valuable;
sealed record Elf(int age, int magic): Valuable;
sealed record Dwarf(int will): Valuable;

sealed class WarSystem {
  List<Valuable> army = new ();

  public WarSystem(int soldiers) {
    for(int i = 0; i < soldiers / 3; i++) army.Add(new Man(1,1));
    for(int i = 0; i < soldiers / 3; i++) army.Add(new Elf(1,1));
    for(int i = 0; i < soldiers / 3; i++) army.Add(new Dwarf(1));
  }

  public int ValueArmy() => army.Sum(s => {
      return s switch {
        Man m   => m.strength * m.stamina,
        Elf e   => e.age * e.magic * 2,
        Dwarf d => d.will * 10,
        _ => throw new Exception("Not an existing soldier race"),
      };
  });
}
