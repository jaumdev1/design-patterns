class Coffee:
    def cost(self):
        pass

class SimpleCoffee(Coffee):
    def cost(self):
        return 5
class CoffeeDecorator(Coffee):
    def __init__(self, coffee):
        self._decorated_coffee = coffee

    def cost(self):
        return self._decorated_coffee.cost()
class MilkDecorator(CoffeeDecorator):
    def __init__(self, coffee):
        super().__init__(coffee)

    def cost(self):
        return super().cost() + 2
class SugarDecorator(CoffeeDecorator):
    def __init__(self, coffee):
        super().__init__(coffee)

    def cost(self):
        return super().cost() + 1


simple_coffee = SimpleCoffee()
print("Custo do café simples:", simple_coffee.cost())

milk_coffee = MilkDecorator(simple_coffee)
print("Custo do café com leite:", milk_coffee.cost())

sugar_milk_coffee = SugarDecorator(milk_coffee)
print("Custo do café com leite e açúcar:", sugar_milk_coffee.cost())
