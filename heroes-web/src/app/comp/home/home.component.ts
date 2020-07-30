import { Component, OnInit } from '@angular/core';
import { Compmetadata } from 'src/app/shared/compmetadata';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  // Simple metada about the component
  metadata = new Compmetadata (
    'home',
    'welcome to superheroes!'
  );

  constructor() { }

  ngOnInit(): void {
  }

}
