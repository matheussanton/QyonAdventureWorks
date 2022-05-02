CREATE TABLE IF NOT EXISTS public.pistacorrida
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    descricao character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT pistacorrida_pkey PRIMARY KEY (id)
)