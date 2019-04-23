export class Category {
    constructor(
      public id: number,
      public name: string) { }
  }
  export class Product {
    constructor(
      public id: number,
      public name: string,
      public category: Category) { }
  }
