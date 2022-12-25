// Classic way
class Adress {
    constructor(street, zip) {
        this.street = street;
        this.zip = zip;
    }
}

class User {
    constructor(name, age, adress, email){ 
        this.name = name;
        this.age = age;
        this.adress = adress;
        this.email = email;
    }
}

const user = new User('Bob', undefined, new Adress('main', '111'));
console.log(user);

// Improved way
class Adress2 {
    constructor(street, zip) {
        this.street = street;
        this.zip = zip;
    }
}

class User2 {
    constructor(name,{ age, adress, email = 'default@email.com'} = { }){ 
        this.name = name;
        this.age = age;
        this.adress = adress;
        this.email = email;
    }
}

const user2 = new User2('Bob', {age: 35, adress: new Adress('coffee', '333')});
console.log(user2);

// Builder
class User3 {
    constructor(name) {
        this.name = name;
    }
}

class UserBuilder {
    constructor(name) {
        this.user = new User3(name);
    }

    setAge(age) {
        this.user.age = age;
        return this;
    }

    setAdress(adress) {
        this.user.adress = adress;
        return this;
    }

    setEmail(email) {
        this.user.email = email;
        return this;
    }

    build() {
        return this.user;
    }
}

const user3 = new UserBuilder('Daniel');
user3.setAge(23).setEmail('user3@email.com').build();
console.log(user3);