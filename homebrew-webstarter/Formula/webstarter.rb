# Documentation: https://docs.brew.sh/Formula-Cookbook
#                https://rubydoc.brew.sh/Formula
class Webstarter < Formula
  desc "Create a full stack project all in a single command"
  homepage "https://github.com/jonathannotis/web-starterkit-cli"
  url "https://github.com/jonathannotis/web-starterkit-cli/releases/download/v1.0.1/webstarter.tar.bz2"
  sha256 "47d455d899075610cd3e21a229182401ae407e17e6f1a4461cc82dd28b241dd9"
  license "MIT"
  version "1.0.1"

  def install
    prefix.install "assets"

    bin.install "webstarter.dll"
  end
end
