using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD.Lib.Faturacion
{
    class Facturacion
    {
        public Facturacion()
        {
            string RFC_Emisor;
            string API_Key;
            string Datos;
            string Cadena_Enviada;

            //'El R.F.C. que emite el Comprobante (de 12 ó de 13 caracteres)
            RFC_Emisor = "INV120628FT7";
            //La API Key que se utilizará para la conexión(16 caracteres)
            API_Key = "E75EDF7625404A35";
            Datos = Datos_del_Comprobante();

            Cadena_Enviada = RFC_Emisor + "~" + API_Key + "~" + Datos;
            //Instancia de servicio web por factura fiel
            com.facturafiel.www.server servidor = new com.facturafiel.www.server();
            string abc = servidor.servicio_timbrado(Cadena_Enviada);
            Console.WriteLine(abc);
        }

        private string Datos_del_Comprobante()
        {
            string Cadena = "";
            //INFORMACIÓN GENERAL DEL COMPROBANTE:
            //Campo OPCIONAL. Valores posibles: SI, NO.
            //Este campo indica si el documento a generar sólo es para realizar pruebas ó es para un timbrado real (ambiente productivo). (Si se omite, en automático se asume que es ambiente real/productivo).
            Cadena += "AmbienteDePruebas=";
            Cadena += "SI" + Environment.NewLine;

            Cadena += "TipoDeComprobante=";
            //Campo OBLIGATORIO. Valores posibles: Ingreso, Egreso, Traslado. (Si se omite regresará ERROR).
            Cadena += "Ingreso" + Environment.NewLine;

            Cadena += "TipoDeFormato=";
            //Campo OBLIGATORIO. Valores posibles: Factura, ReciboDeHonorarios, ReciboDeArrendamiento, NotaDeCredito, NotaDeCargo, CartaPorte. (Si se omite regresará ERROR).
            Cadena += "Factura" + Environment.NewLine;

            Cadena += "Serie=";
            //Campo OPCIONAL. Puede ser vacío, no puede contener números, sólo letras. (Si se omite será vacío).
            Cadena += "A" + Environment.NewLine;

            Cadena += "Folio=";
            //Campo OBLIGATORIO. Debe ser Numérico. (Si se omite se usará en automático el último folio usado + 1).
            Cadena += "103" + Environment.NewLine;

            Cadena += "FormaDePago=";
            //Campo OBLIGATORIO. (Si se omite se usará en automático "Pago en una sola exhibición").
            Cadena += "Pago en una sola exhibición" + Environment.NewLine;

            Cadena += "CondicionesDePago=";
            //Campo OBLIGATORIO. (Si se omite se usará en automático "Contado").
            Cadena += "Contado" + Environment.NewLine;

            Cadena += "MetodoDePago=";
            //Campo OBLIGATORIO. (Si se omite se usará en automático "Efectivo").
            Cadena += "Tarjeta de Crédito" + Environment.NewLine;

            Cadena += "LugarExpedicion=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "Guadalajara, Jalisco" + Environment.NewLine;

            Cadena += "NumCtaPago=";
            //Campo OPCIONAL. 4 últimos dígitos de la cuenta con la que pagó el cliente. (Si se omite se usará en automático "NO IDENTIFICADO").
            Cadena += "4528" + Environment.NewLine;

            Cadena += "SubTotal=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "209855.50" + Environment.NewLine;

            Cadena += "Descuento=";
            //Campo OPCIONAL. (Si se omite se usará en automático "0.00").
            Cadena += "20985.55" + Environment.NewLine;

            Cadena += "DescuentoPorcentaje=";
            //Campo OPCIONAL. (Si se omite se usará en automático "0.00").
            Cadena += "10" + Environment.NewLine;

            Cadena += "MotivoDescuento=";
            //Campo OPCIONAL. (Si se omite se usará en automático "No aplica").
            Cadena += "Por pronto pago" + Environment.NewLine;

            Cadena += "NuevoSubTotal=";
            //Campo OPCIONAL. Es el valor obtenido del SubTotal MENOS el Descuento (Si se omite se usará en automático el mismo valor del SubTotal).
            Cadena += "188869.95" + Environment.NewLine;

            Cadena += "Total=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "219089.14" + Environment.NewLine;

            Cadena += "Moneda=";
            //Campo OBLIGATORIO. (Si se omite se usará en automático "MXN").
            Cadena += "MXN" + Environment.NewLine;

            Cadena += "TipoDeCambio=";
            //Campo OBLIGATORIO. (Si se omite se usará en automático "1.00").
            Cadena += "1.00" + Environment.NewLine;

            //LAS OBSERVACIONES EXTRA DEL DOCUMENTO NO FORMAN PARTE DEL XML, PERO PUEDE UTILIZARLAS PARA IMPRIMIR EN EL PDF MUCHA INFORMACIÓN EXTRA,
            //Por ejemplo, datos no fiscales, pero que sí sirven para efectos operativos o comerciales, tales como: Números de Guía, Números de Placa,
            //Números de Ordenes de Pedido, Números de Contrato, Nombres de los Bancos y cualquier otro dato que necesite, ya que son campos abiertos a su discreción.
            //La API permite enviar hasta 20 Observaciones Extra ("Observaciones_1" a "Observaciones_20"), y el limite para cada campo es de 1,000 caracteres
            Cadena += "Observaciones_1=";
            //Campo OPCIONAL. Observaciones EXTRA del Documento.
            Cadena += "Número de Guía Mensajería AF7512141282" + Environment.NewLine;

            Cadena += "Observaciones_2=";
            //Campo OPCIONAL. Observaciones EXTRA del Documento.
            Cadena += "Esta factura proviene del pedido #2569" + Environment.NewLine;

            Cadena += "Observaciones_3=";
            //Campo OPCIONAL. Observaciones EXTRA del Documento.
            Cadena += "No. de Contrato 346";

            Cadena += "PrecioPredeterminado=";
            //Campo OPCIONAL. Valores posibles: 1, 2, 3, 4, 5. (Si se omite será "1").
            Cadena += "1" + Environment.NewLine;

            Cadena += "DecimalesDePrecision=";
            //Campo OPCIONAL. Valores posibles: 2, 3, 4, 5, 6. (Si se omite será "2").
            Cadena += "2" + Environment.NewLine;

            Cadena += "RegimenEmisor=";
            //Campo OPCIONAL. (Si se omite se utilizará el Régimen Fiscal declarado dentro de la cuenta en FacturaFiel.Com).
            Cadena += "Regimen General de Ley" + Environment.NewLine;

            //DATOS DEL CLIENTE / PROVEEDOR QUE RECIBE EL COMPROBANTE:

            Cadena += "RFCReceptor=";
            //Campo OBLIGATORIO. 13 caracteres para persona física, 12 caracteres para persona moral. (Si se omite regresará ERROR).
            Cadena += "RUT780818KF7" + Environment.NewLine;

            Cadena += "NombreReceptor=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "Cliente SA de CV" + Environment.NewLine;

            Cadena += "Pais=";
            //Campo OBLIGATORIO. (Si se omite se usará en automático "México").
            Cadena += "México" + Environment.NewLine;

            Cadena += "Estado=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "Oaxaca" + Environment.NewLine;

            Cadena += "Localidad=";
            //Campo OBLIGATORIO. Aquí va la Localidad ó Ciudad (Si se omite regresará ERROR).
            Cadena += "Villa Sola de Vega" + Environment.NewLine;

            Cadena += "Municipio=";
            //Campo OBLIGATORIO. Aquí va el Municipio ó Delegación (Si se omite regresará ERROR).
            Cadena += "Villa Sola de Vega" + Environment.NewLine;

            Cadena += "Colonia=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "Campo de la Primavera" + Environment.NewLine;

            Cadena += "Calle=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "Avenida Siempre Viva" + Environment.NewLine;

            Cadena += "NoExterior=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "742" + Environment.NewLine;

            Cadena += "NoInterior=";
            //Campo OPCIONAL.
            Cadena += "2" + Environment.NewLine;

            Cadena += "CodigoPostal=";
            //Campo OBLIGATORIO. (Si se omite regresará ERROR).
            Cadena += "71427" + Environment.NewLine;

            Cadena += "Referencia=";
            //Campo OPCIONAL.
            Cadena += "Junto a Ranchería El Olvido" + Environment.NewLine;

            Cadena += "Telefono=";
            //Campo OPCIONAL.
            Cadena += "5553225588" + Environment.NewLine;

            Cadena += "Email=";
            //Campo OPCIONAL.
            Cadena += "clientesa@cliente.com" + Environment.NewLine;

            //DATOS DEL CONSIGNATARIO / ENTREGA DE MERCANCÍA (Nota: Todos estos campos son OPCIONALES y no forman parte del XML, pero sí los puede imprimir en la generación del PDF):

            Cadena += "CO_Nombre=";
            Cadena += "Juan Domínguez" + Environment.NewLine;

            Cadena += "CO_Pais=";
            Cadena += "México" + Environment.NewLine;

            Cadena += "CO_Estado=";
            Cadena += "Distrito Federal" + Environment.NewLine;

            Cadena += "CO_Localidad=";
            Cadena += "Ciudad de México" + Environment.NewLine;

            Cadena += "CO_Municipio=";
            Cadena += "Cuauhtémoc" + Environment.NewLine;

            Cadena += "CO_Colonia=";
            Cadena += "Condesa" + Environment.NewLine;

            Cadena += "CO_Calle=";
            Cadena += "Cuernavaca" + Environment.NewLine;

            Cadena += "CO_NoExterior=";
            Cadena += "24" + Environment.NewLine;

            Cadena += "CO_NoInterior=";
            Cadena += "202" + Environment.NewLine;

            Cadena += "CO_CodigoPostal=";
            Cadena += "06140" + Environment.NewLine;

            Cadena += "CO_Referencia=";
            Cadena += "Entre Fernando Montes de Oca y Juan Escutia" + Environment.NewLine;

            Cadena += "CO_Telefono=";
            Cadena += "5552863399" + Environment.NewLine;

            //PARTIDAS / CONCEPTOS DEL COMPROBANTE:
            Cadena += "NumeroDePartidas=";
            //Campo OBLIGATORIO. Aquí va el número de lineas/partidas/conceptos que llevará el comprobante. Debe ser númerico, MAYOR a CERO y MENOR ó igual a 1,000. (Si se omite regresará ERROR).
            Cadena += "1" + Environment.NewLine;

            //Concepto # 1
            Cadena += "Concepto_1_Cantidad=";
            Cadena += "3" + Environment.NewLine;

            Cadena += "Concepto_1_Unidad=";
            Cadena += "PIEZA" + Environment.NewLine;

            Cadena += "Concepto_1_NoIdentificacion=";
            Cadena += "7501055305346" + Environment.NewLine;

            Cadena += "Concepto_1_Descripcion=";
            Cadena += "Coca Cola Light de 1 Litro" + Environment.NewLine;

            Cadena += "Concepto_1_ValorUnitario=";
            Cadena += "18.50" + Environment.NewLine;

            Cadena += "Concepto_1_Importe=";
            Cadena += "55.50" + Environment.NewLine;

            //IMPUESTOS DEL COMPROBANTE:
            Cadena += "IVATasa=";
            //Campo OPCIONAL. Tasa en porcentaje del IVA Trasladado de todo el Comprobante.
            Cadena += "16.00" + Environment.NewLine;

            Cadena += "IVATrasladado=";
            //Campo OPCIONAL. Total del IVA Trasladado de todo el Comprobante.
            Cadena += "100.00" + Environment.NewLine;

            Cadena += "IEPSTasa=";
            //Campo OPCIONAL. Tasa en porcentaje del IEPS Trasladado de todo el Comprobante.
            Cadena += "100.00" + Environment.NewLine;

            Cadena += "IEPSTrasladado=";
            //Campo OPCIONAL. Total del IEPS Trasladado de todo el Comprobante.
            Cadena += "100.00" + Environment.NewLine;

            Cadena += "IVARetenido=";
            //Campo OPCIONAL. Total del IVA Retenido de todo el Comprobante.
            Cadena += "100.00" + Environment.NewLine;

            Cadena += "ISRRetenido=";
            //Campo OPCIONAL. Total del ISR Retenido de todo el Comprobante.
            Cadena += "100.00" + Environment.NewLine;

            Cadena += "TotalDeImpuestosRetenidos=";
            //Valor de la suma total de los impuestos RETENIDOS.
            Cadena += "100.00" + Environment.NewLine;

            Cadena += "TotalDeImpuestosTrasladados=";
            //Valor de la suma total de los impuestos TRASLADADOS.
            Cadena += "100.00" + Environment.NewLine;

            //COMPLEMENTOS ESPECIALES A NIVEL COMPROBANTE:
            //DONATARIAS (Emisión de Facturas Electrónicas por DONATIVOS):
            Cadena += "Donativos_NoDeAutorizacion=";
            //Atributo requerido para expresar el número del oficio en que se haya informado a la organización civil o fideicomiso,
            //la procedencia de la autorización para recibir donativos deducibles, o su renovación correspondiente otorgada por el Servicio de Administración Tributaria.
            Cadena += "8532" + Environment.NewLine;

            Cadena += "Donativos_FechaDeAutorizacion=";
            //Atributo requerido para expresar la fecha del oficio en que se haya informado a la organización civil o fideicomiso, la procedencia de la autorización para recibir donativos deducibles, o su renovación correspondiente otorgada por el Servicio de Administración Tributaria.
            Cadena += "2013-06-13" + Environment.NewLine;

            Cadena += "Donativos_Leyenda=";
            //Atributo requerido para señalar de manera expresa que el comprobante que se expide se deriva de un donativo.
            Cadena += "Este comprobante ampara un donativo, el cual será destinado por la donataria a los fines propios de su objeto social. "+
                "En el caso de que los bienes donados hayan sido deducidos previamente para los efectos del impuesto sobre la renta, este donativo "+
                "no es deducible. La reproducción no autorizada de este comprobante constituye un delito en los términos de las disposiciones fiscales." + Environment.NewLine;

            //IMPUESTOS LOCALES, ESTATALES Y ESPECIALES (Complemento para incluir Otros Derechos e Impuestos en la Factura Electrónica):
            //Se pueden concatenar hasta 10 para cada Comprobante (5 traslados y 5 retenciones)
            Cadena += "TotalDeTraslados=";
            //Valor de la suma total de los impuestos locales TRASLADADOS.
            Cadena += "100.00" + Environment.NewLine;

            Cadena += "TotalDeRetenciones=";
            //Valor de la suma total de los impuestos locales RETENIDOS.
            Cadena += "100.00" + Environment.NewLine;

            Cadena += "NombreImpuestoTrasladado1=";
            //Nombre del Impuesto Trasladado que se utiliza.
            Cadena += "Impuesto al Hospedaje" + Environment.NewLine;

            Cadena += "TasaImpuestoTrasladado1=";
            //Tasa en porcentaje del Impuesto Trasladado.
            Cadena += "3.00" + Environment.NewLine;

            Cadena += "ImporteImpuestoTrasladado1=";
            //Valor del Impuesto Trasladado.
            Cadena += "30.00" + Environment.NewLine;

            Cadena += "NombreImpuestoTrasladado2=";
            //Nombre del Impuesto Trasladado que se utiliza.
            Cadena += "Impuesto Estatal" + Environment.NewLine;

            Cadena += "TasaImpuestoTrasladado2=";
            //Tasa en porcentaje del Impuesto Trasladado.
            Cadena += "7.00" + Environment.NewLine;

            Cadena += "ImporteImpuestoTrasladado2=";
            //Valor del Impuesto Trasladado.
            Cadena += "70.00" + Environment.NewLine;

            Cadena += "NombreImpuestoRetenido1=";
            //Nombre del Impuesto Retenido que se utiliza.
            Cadena += "Impuesto Federal" + Environment.NewLine;

            Cadena += "TasaImpuestoRetenido1=";
            //Tasa en porcentaje del Impuesto Retenido.
            Cadena += "6.00" + Environment.NewLine;

            Cadena += "ImporteImpuestoRetenido1=";
            //Valor del Impuesto Retenido.
            Cadena += "60.00" + Environment.NewLine;

            Cadena += "NombreImpuestoRetenido2=";
            //Nombre del Impuesto Retenido que se utiliza.
            Cadena += "Impuesto Especial" + Environment.NewLine;

            Cadena += "TasaImpuestoRetenido2=";
            //Tasa en porcentaje del Impuesto Retenido.
            Cadena += "4.00" + Environment.NewLine;

            Cadena += "ImporteImpuestoRetenido2=";
            //Valor del Impuesto Retenido.
            Cadena += "40.00" + Environment.NewLine;

            return Cadena;
        }
    }
}