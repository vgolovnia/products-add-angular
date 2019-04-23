import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from 'src/app/products/products.component';
import { ProductItemComponent } from 'src/app/product-item/product-item.component';

const routes: Routes = [
  {
    path: 'products/:type',
    component: ProductsComponent
  },
  {
    path: 'product/:id',
    component: ProductItemComponent
  },
  {
    path: '**',
    redirectTo: 'products/all'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
