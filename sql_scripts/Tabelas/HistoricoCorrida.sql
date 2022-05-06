CREATE TABLE IF NOT EXISTS public.historicocorrida
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    competidorid integer NOT NULL,
    pistacorridaid integer NOT NULL,
    datacorrida date NOT NULL,
    tempogasto numeric NOT NULL,
    CONSTRAINT historicocorrida_pkey PRIMARY KEY (id),
    CONSTRAINT historicocorrida_competidorid_fkey FOREIGN KEY (competidorid)
        REFERENCES public.competidores (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT historicocorrida_pistacorridaid_fkey FOREIGN KEY (pistacorridaid)
        REFERENCES public.pistacorrida (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
