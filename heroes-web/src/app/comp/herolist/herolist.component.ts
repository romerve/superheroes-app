import { Component, OnInit } from '@angular/core';
import { Compmetadata } from 'src/app/shared/compmetadata';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { HerolistService } from 'src/app/svc/herolist.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-herolist',
  templateUrl: './herolist.component.html',
  styleUrls: ['./herolist.component.sass'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ]
})
export class HerolistComponent implements OnInit {

  // Simple metada about the component
  metadata = new Compmetadata (
    'superheroes',
    'list of superheroes'
  );

  heroes = [];
  heroesData$: Observable<any>;
  columnList: string[] = [ 'name', 'rank', 'rating', 'popularity' ];
  blue = 'lightblue';
  grey = 'lightgrey';
  green = 'lightgreen';
  pink = 'lightpink';

  constructor( private heroService: HerolistService ) { }

  ngOnInit(): void {

    this.heroesData$ = this.heroService.fetchHeros();
    this.heroesData$.subscribe( res => {
      this.setSuperHeroes(res);
    });

  }

  setSuperHeroes( heros ) {
    this.heroes = heros;

    console.log("----- HEROS func------");
    console.log(this.heroes);
  }

}

export interface Tile {
  color: string;
  cols: number;
  rows: number;
  name: string;
}
