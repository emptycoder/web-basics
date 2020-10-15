import { Component, OnInit } from '@angular/core';
import { DogService } from './dog.service';
import { Dog } from './dog';

@Component({
  selector: 'app-cat',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.css']
})
export class DogComponent implements OnInit {
  inputDog: Dog;
  dogs: Dog[];

  constructor(private dogService: DogService) { }

  ngOnInit() {
    this.dogService.get().subscribe(data => {
      this.dogs = data;
    });
    this.inputDog = <Dog>{};
  }

  add() {
    this.dogService.add(this.inputDog).subscribe(result => alert(result.id + " " + result.name + " " + result.age));
  }
}
