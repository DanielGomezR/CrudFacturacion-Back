using AutoMapper;
using SistemaFacturacion.Aplicacion.DTO;
using SistemaFacturacion.Aplicacion.Interface;
using SistemaFacturacion.Aplicacion.ViewModels;
using SistemaFacturacion.Dominio.Data;
using SistemaFacturacion.Dominio.Entidades;
using SistemaFacturacion.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SistemaFacturacion.Aplicacion.Servicios
{
    public class FacturaServicios : IFacturaServicios
    {
        private readonly IFactura _IFactura;
        private readonly IDetalleFactura _IDetalleFactura;
        private readonly IProducto _IProducto; 
        private readonly IMapper _mapper;

        public FacturaServicios(
            IFactura factura,
            IDetalleFactura detalleFactura, 
            IProducto producto,
            IProducto producto2,
            IMapper mapper)
        {
            _IFactura = factura;
            _IDetalleFactura = detalleFactura;
            _IProducto = producto;
            _mapper = mapper;
        }

        public FacturaViewModel BuscarFactura(int idfactura)
        {
            var factura = _IFactura.BuscarFactura(idfactura);
            return new FacturaViewModel
            {
                id = factura.id, 
                fecha = factura.fecha.ToString("yyyy-MM-dd"),
                subtotal = factura.subtotal,
                iva = factura.iva,
                total = factura.total,
                idcliente = factura.idcliente,
                createdday = factura.createdday.ToString("dd-MM-yyyy HH:mm:ss"),
                cliente = new ClienteViewModel(factura.Cliente),
                detalle = factura.DetalleFacturas.
                                        Select(d => new DetalleFacturaViewModel
                                        {
                                            id = d.id,
                                            subtotal = d.subtotal,
                                            cantidad = d.cantidad,
                                            idfactura = factura.id,
                                            idproducto = d.idproducto,
                                            precio = d.Producto.precio,
                                            producto = d.Producto.descripcion
                                        }).ToList()
            };
        }

        public bool EditarFactura(DataContext contextTransaccion, ActualizarFacturaDTO editarFactura)
        {
            // Se actualiza la factura
            var facturaGuardada = _IFactura.BuscarFactura(editarFactura.id);
            if (facturaGuardada != null)
            {
                facturaGuardada.fecha = editarFactura.fecha;
                facturaGuardada.subtotal = editarFactura.subtotal;
                facturaGuardada.iva = editarFactura.iva;
                facturaGuardada.total = editarFactura.total;
                facturaGuardada.idcliente = editarFactura.idcliente;
                _IFactura.ActualizarFactura(contextTransaccion, facturaGuardada);


                // Se actualiza el detalle
                var facturasDetalles = _IDetalleFactura.BuscarDetalleFacturaxFactura(editarFactura.id);

                // Se elimina el detalle actual
                foreach (var facturasDetalle in facturasDetalles)
                {
                    _IDetalleFactura.EliminarDetalleFactura(contextTransaccion, facturasDetalle);

                    _IProducto.SumarCantidadProducto(contextTransaccion, facturasDetalle.idproducto, facturasDetalle.cantidad);
                }

                // Se crea el nuevo detalel 
                foreach (var detalle in editarFactura.detalle)
                {
                    detalle.idfactura = editarFactura.id;

                    var nuevoDetalle = _mapper.Map<DetalleFactura>(detalle);
                    _IDetalleFactura.CrearDetalleFactura(contextTransaccion, nuevoDetalle);

                    _IProducto.RestarCantidadProducto(contextTransaccion, detalle.idproducto, detalle.cantidad);
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool EliminarFactura(DataContext contextTransaccion, int idfactura)
        {
            var factura = _IFactura.BuscarFactura(idfactura);
            if (factura != null)
            {
                _IFactura.EliminarFactura(contextTransaccion, factura);
                foreach (var detalle in factura.DetalleFacturas)
                {
                    //var producto = _IProducto.BuscarProducto(detalle.idproducto);
                    _IProducto.SumarCantidadProducto(contextTransaccion, detalle.idproducto, detalle.cantidad); 
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public int IngresarFactura(DataContext contextTransaccion, CrearFacturaDTO ingresarFactura)
        {
            Factura factura = _mapper.Map<Factura>(ingresarFactura);
            int idfactura = _IFactura.RegistrarFactura(contextTransaccion, factura);
            foreach (var detalle in ingresarFactura.detalle)
            {
                detalle.idfactura = idfactura;

                var nuevoDetalle = _mapper.Map<DetalleFactura>(detalle);
                _IDetalleFactura.CrearDetalleFactura(contextTransaccion, nuevoDetalle);

                //var producto = _IProducto.BuscarProducto(detalle.idproducto);
                _IProducto.RestarCantidadProducto(contextTransaccion, detalle.idproducto, detalle.cantidad);
            }
            return idfactura;
        }

        public List<FacturaViewModel> ListarFacturas()
        {
            var factura = _IFactura.ListarFacturas();
            if (factura.Any())
            {
                return factura.Select(f => new FacturaViewModel
                {
                    id = f.id, 
                    fecha = f.fecha.ToString("yyyy-MM-dd"),
                    subtotal = f.subtotal,
                    iva = f.iva,
                    total = f.total,
                    idcliente = f.idcliente, 
                    createdday = f.createdday.ToString("dd-MM-yyyy HH:mm:ss") ,
                    cliente = new ClienteViewModel(f.Cliente),
                    detalle = f.DetalleFacturas.
                                        Select(d => new DetalleFacturaViewModel
                                        {
                                            id = d.id,
                                            subtotal = d.subtotal,
                                            cantidad = d.cantidad,
                                            idfactura = f.id,
                                            idproducto = d.idproducto,
                                            precio = d.Producto.precio,
                                            producto = d.Producto.descripcion
                                        }).ToList()
                }) .ToList();
            }
            else
            {
                return new List<FacturaViewModel>();
            }
        }
    }
}
