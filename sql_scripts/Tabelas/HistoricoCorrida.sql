CREATE TABLE IF NOT EXISTS public.competidores
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    nome character varying(150) COLLATE pg_catalog."default" NOT NULL,
    sexo character(1) COLLATE pg_catalog."default" NOT NULL,
    temperaturamediacorpo numeric NOT NULL,
    peso numeric NOT NULL,
    altura numeric NOT NULL,
    CONSTRAINT competidores_pkey PRIMARY KEY (id)
)