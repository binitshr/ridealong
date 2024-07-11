import { AppProps } from "next/app"
import "../styles/index.css"
import "../styles/main.css"

import { useApp } from "../lib/gateway"
import { useEffect } from "react";
import { NextUIProvider } from "@nextui-org/react";
import { ThemeProvider as NextThemesProvider } from "next-themes";

export default function ridealong({ Component, pageProps }: AppProps) {
  useEffect(() => {
    (async () => useApp().load())()
  }, [])
  return (
    <NextUIProvider>     
      <NextThemesProvider defaultTheme="light">
        <Component {...pageProps} />
      </NextThemesProvider>
    </NextUIProvider>
  )
}