
export class Restaurants {
  ID: string;
  NAME: string;

  constructor(data: any) {
    this.ID = data.ID;
    this.NAME = data.NAME;
  }
}
