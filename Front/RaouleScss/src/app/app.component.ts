import { Component, OnInit } from '@angular/core';
import { HROpenLayerViewService } from './shared/services/hropen-layer-view.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {

  constructor(private layerService : HROpenLayerViewService){
    
  }
  ngOnInit(): void {
    this.layerService.loadViewOrigin();
  }
}