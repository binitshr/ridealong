import Alert from "./alert"
import Nav from "./nav"
import Footer from "./footer"
import Meta from "./meta"
import Providers from './providers'


type Props = {
  preview?: boolean
  children: React.ReactNode
}

const Layout = ({ preview, children }: Props) => {
  return (
    <>
      <Meta />
      <Nav />
        <Providers>
            <div className="min-h-screen">
                <main>{children}</main>
            </div>
            <Footer />
        </Providers>
    </>
  )
}

export default Layout
