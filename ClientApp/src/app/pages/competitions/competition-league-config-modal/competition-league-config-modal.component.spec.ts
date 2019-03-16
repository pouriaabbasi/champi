import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionLeagueConfigModalComponent } from './competition-league-config-modal.component';

describe('CompetitionLeagueConfigModalComponent', () => {
  let component: CompetitionLeagueConfigModalComponent;
  let fixture: ComponentFixture<CompetitionLeagueConfigModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionLeagueConfigModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionLeagueConfigModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
