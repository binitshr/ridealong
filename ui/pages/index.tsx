import Container from "../components/container"
import Layout from "../components/layout"
import { getAllPosts } from "../lib/api"
import Head from "next/head"
import { CMS_NAME } from "../lib/constants"
import Post from "../types/post"
import { Button } from "@nextui-org/button"
import { Link } from "@nextui-org/link"

type Props = {
  allPosts: Post[]
}

const Index = ({ allPosts }: Props) => {
  const heroPost = allPosts[0]
  const morePosts = allPosts.slice(2)
  const title = `Next.js Example with ${CMS_NAME}`

  return (
    <>
      <Layout>
        <Head>
          <title>{title}</title>
        </Head>
        <Container>
         <div>
           This is a random text
         </div>
         <div>
         <Button
            isExternal
            as={Link}
            className="text-sm font-normal text-default-600 bg-default-100"
            href=""
            variant="flat"
          >
            Sponsor
          </Button>
         </div>
        </Container>
      </Layout>
    </>
  )
}

export default Index

export const getStaticProps = async () => {
  const allPosts = getAllPosts([
    'title',
    'date',
    'slug',
    'author',
    'coverImage',
    'excerpt',
  ])

  return {
    props: { allPosts },
  }
}
