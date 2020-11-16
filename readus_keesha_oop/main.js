class Animal{
    constructor(name){
        this._name = name;
    }
    speak(){
        return `${this._name} makes a noise.`;
    }


}
let animal = new Animal('Pet');
console.log(animal.speak());
//Inheritance is being used by me extending the animal class
class Cat extends Animal{
    constructor(name, breed) {
       super(name);
       //Encapsulation is being used by me using a backing variable for the property
        this._breed = breed;
    }
    //Polymorphism is being used by me overriding the speak method
    speak(){
        return `${this._name} purrs`
    }
    train(){
        return `${this._name} is a ${this._breed} that uses a litter box`;
    }
}

let cat = new Cat('Fred', 'Persian')

console.log(cat.train());
console.log(cat.speak());