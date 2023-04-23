import { Component, OnInit } from '@angular/core';
import { HROpenLayerViewService } from './shared/services/hropen-layer-view.service';
import { HRViewCoordinate } from './shared/models/hrview-coordinate';

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
    setInterval(()=> {
      this.layerService.saveViewOrigin(new HRViewCoordinate())
   }
   ,10000);
  }
}