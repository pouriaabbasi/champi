import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameTypesComponent } from './game-types.component';

describe('GameTypesComponent', () => {
  let component: GameTypesComponent;
  let fixture: ComponentFixture<GameTypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameTypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
